using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SysAdminUnitsApi.Models;
using SysAdminUnitsApi.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SysAdminUnitsApi;

namespace Norbit.Crm.Zaikin.SysAdminUnitsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SysAdminUnitController : ControllerBase, IEntityQueryableServiceAsync<SysAdminUnit>
    {
        /// <summary>
        /// Экземпляр объекта контекста базы данных.
        /// </summary>
        private readonly DatabaseContext _dbContext;

        /// <summary>
        /// Максимальное количество записей в выборке.
        /// </summary>
        private const int MaxRecordsCount = 1000;

        /// <summary>
        /// Инициализирует объект контекста базы данных.
        /// </summary>
        public SysAdminUnitController(DatabaseContext dataBaseContext)
        {
            _dbContext = dataBaseContext;
        }

        /// <summary>
        /// Возвращает из базы данных всех пользователей.
        /// Выводимая информация о пользователе: идентификатор, имя, тип, информация о контакте, информация об аккаунте, активность
        /// культура (страна). Информация об аккаунте содержит: имя, номер телефона,
        /// тип адреса, адрес, город, регион, страна, веб-сайт, компетентность.
        /// Информация о контакте включает: имя, должность, заголовок должности, название департамента. 
        /// </summary>
        /// <param name="count">Количество возвращаемых записей.</param>
        /// <param name="from">Индекс смещения в выборке.</param>
        /// <returns>Статус выполнения запроса со всеми пользователями.</returns>
        [HttpGet("GetEntities")]
        public async Task<IActionResult> GetEntities(int from = 0, int count = 1000)
        {
            Argument.ValidateIntervalParams(from, count, MaxRecordsCount);

            var sysAdminUnits = await GetListOfAllUnits(from, count);
            return Ok(sysAdminUnits);
        }

        /// <summary>
        /// Возвращает пользователя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Статус выполнения запроса с пользователем, найденным по идентификатору.</returns>
        [HttpGet("GetEntityById")]
        public async Task<IActionResult> GetEntityById(Guid id)
        {
            var actionResult = ValidateGuid(id, nameof(id));

            if (actionResult != null)
            {
                return actionResult;
            }

            var sysAdminUnitsById = await GetListOfAllUnits();
            sysAdminUnitsById = sysAdminUnitsById.Where(u => u.Id == id);

            if (!sysAdminUnitsById.Any())
            {
                return NotFound($"По идентификатору {id} ничего не найдено.");
            }

            return Ok(sysAdminUnitsById);
        }

        /// <summary>
        /// Создаёт пользователя.
        /// </summary>
        /// <param name="sysAdminUnit">Пользователь.</param>
        /// <returns>Возвращает статус выполнения запроса с добавленной сущностью.</returns>
        [HttpPost("InsertEntity")]
        public async Task<IActionResult> InsertEntity([FromBody] SysAdminUnit sysAdminUnit)
        {
            var actionResult = SysAdminUnitArgument.ValidateSysAdminUnit(sysAdminUnit);

            if (actionResult != null)
            {
                return actionResult;
            }

            var encryptedPassword = await AesCoder.EncryptPasswordAsync(sysAdminUnit.UserPassword);
            var newSysAdminUnit = new SysAdminUnit
            {
                Id = new Guid(),
                Name = sysAdminUnit.Name,
                ParentRoleId = sysAdminUnit.ParentRoleId,
                UserPassword = encryptedPassword,
                UnitType = sysAdminUnit.UnitType,
                ContactId = sysAdminUnit.ContactId,
                AccountId = sysAdminUnit.AccountId,
                Active = sysAdminUnit.Active,
                SysCultureId = sysAdminUnit.SysCultureId
            };

            await _dbContext.SysAdminUnits.AddAsync(newSysAdminUnit);
            await _dbContext.SaveChangesAsync();

            return Ok(newSysAdminUnit);
        }

        /// <summary>
        /// Обновляет пользователя.
        /// </summary>
        /// <param name="sysAdminUnit">Пользователь.</param>
        /// <returns>Статус выполнения запроса с обновлённой сущностью.</returns>
        [HttpPut("UpdateEntity")]
        public async Task<IActionResult> UpdateEntity([FromBody] SysAdminUnit sysAdminUnit)
        {
            var validationgGuidActionResult = ValidateGuid(sysAdminUnit.Id, nameof(sysAdminUnit.Id));

            if (validationgGuidActionResult != null)
            {
                return validationgGuidActionResult;
            }

            var updatingSysAdminUnit = await FindUnitByIdAsync(sysAdminUnit.Id);

            var validationgSysAdminUnitActionResult = SysAdminUnitArgument.ValidateSysAdminUnit(updatingSysAdminUnit, false);

            if (validationgSysAdminUnitActionResult != null)
            {
                return validationgSysAdminUnitActionResult;
            }

            if (!string.IsNullOrEmpty(sysAdminUnit.UserPassword))
            {
                var encryptedPassword = await AesCoder.EncryptPasswordAsync(sysAdminUnit.UserPassword);
                updatingSysAdminUnit.UserPassword = encryptedPassword;
            }

            if (!string.IsNullOrEmpty(sysAdminUnit.Name))
            {
                updatingSysAdminUnit.Name = sysAdminUnit.Name;
            }

            updatingSysAdminUnit.ParentRoleId = sysAdminUnit.ParentRoleId;
            updatingSysAdminUnit.AccountId = sysAdminUnit.AccountId;
            updatingSysAdminUnit.ContactId = sysAdminUnit.ContactId;
            updatingSysAdminUnit.SysCultureId = sysAdminUnit.SysCultureId;

            _dbContext.SysAdminUnits.Update(updatingSysAdminUnit);
            await _dbContext.SaveChangesAsync();

            return Ok(updatingSysAdminUnit);
        }


        /// <summary>
        /// Удаляет пользователя из БД.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Статус выполнения запроса с идентификатором удалённой сущности.</returns>
        [HttpDelete("DeleteEntity")]
        public async Task<IActionResult> DeleteEntity([BindRequired] Guid id)
        {
            var actionResult = ValidateGuid(id, nameof(id));

            if (actionResult != null)
            {
                return actionResult;
            }

            var sysAdminUnit = await FindUnitByIdAsync(id);
            _dbContext.SysAdminUnits.Remove(sysAdminUnit);
            await _dbContext.SaveChangesAsync();

            return Ok(sysAdminUnit.Id);
        }

        /// <summary>
        /// Активирует пользователя.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Статус выполнения запроса.</returns>
        [HttpPut("ActivateUnit")]
        public async Task<IActionResult> ActivateUnit(Guid id)
        {
            var actionResult = await SetUnitActive(id, true);
            return actionResult;
        }

        /// <summary>
        /// Деактивирует пользователя.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Статус выполнения запроса.</returns>
        [HttpPut("DeactivateUnit")]
        public async Task<IActionResult> DeactivateUnit(Guid id)
        {
            var actionResult = await SetUnitActive(id, false);
            return actionResult;
        }

        /// <summary>
        /// Устанавливает значение активности.
        /// </summary>
        /// <param name="isActive">Активность.</param>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Объект статуса выполнения запроса.</returns>
        private async Task<IActionResult> SetUnitActive(Guid id, bool isActive)
        {
            var actionResult = ValidateGuid(id, nameof(id));

            if (actionResult != null)
            {
                return actionResult;
            }

            var sysAdminUnit = await FindUnitByIdAsync(id);
            sysAdminUnit.Active = isActive;

            _dbContext.SysAdminUnits.Update(sysAdminUnit);
            await _dbContext.SaveChangesAsync();

            return Ok("Успешно.");
        }

        /// <summary>
        /// Валидирует гуид на null и пустоту.
        /// </summary>
        /// <param name="guid">Проверяемый гуид.</param>
        /// <param name="displayParameterName">Отображаемое имя параметра в ошибке.</param>
        /// <returns>Объект статуса выполнения запроса.</returns>
        private IActionResult ValidateGuid(Guid guid, string displayParameterName)
        {
            if (guid == null)
            {
                return BadRequest($"Гуид {displayParameterName} не может быть null");
            }

            if (guid == Guid.Empty)
            {
                return BadRequest($"Гуид {displayParameterName} не может быть пустым.");
            }

            return null;
        }

        /// <summary>
        /// Возвращает всех пользователей из базы данных.
        /// </summary>
        /// <param name="count">Количество возвращаемых записей.</param>
        /// <param name="from">Индекс смещения в выборке.</param>
        /// <returns>Пользователей.</returns>
        private async Task<IEnumerable<SysAdminUnit>> GetListOfAllUnits(int from = 0, int count = 1000)
        {
            var sysAdminUnits =
                from sysAdminUnit in await _dbContext.SysAdminUnits.Skip(@from).Take(count).ToListAsync()

                    // Левое соединение контакта к пользователю.
                join joinedContact in await _dbContext.Contacts.ToListAsync()
                    on sysAdminUnit.ContactId equals joinedContact.Id
                    into unitContacts

                from contact in unitContacts.DefaultIfEmpty()

                    // Левое соединение культуры к пользователю.
                join joinedCulture in await _dbContext.Cultures.ToListAsync()
                    on sysAdminUnit.SysCultureId equals joinedCulture.Id
                    into unitCulture

                from culture in unitCulture.DefaultIfEmpty()

                    // Левое соединение должности к контакту.
                join joinedJob in _dbContext.Jobs.ToList()
                    on contact?.JobId equals joinedJob.Id
                    into unitJobs

                from job in unitJobs.DefaultIfEmpty()

                    // Левое соединение департамента к контакту.
                join joinedDepartment in await _dbContext.Departments.ToListAsync()
                    on contact?.DepartmentId equals joinedDepartment.Id
                    into unitDepartments

                from department in unitDepartments.DefaultIfEmpty()

                    // Левое соединение города к контакту.
                join joinedCity in _dbContext.Cities
                    on contact?.CityId equals joinedCity.Id
                    into unitCities

                from city in unitCities.DefaultIfEmpty()

                    // Левое соединение региона к контакту.
                join joinedRegion in _dbContext.Regions
                    on contact?.CityId equals joinedRegion.Id
                    into unitRegion

                from region in unitRegion.DefaultIfEmpty()

                    // Левое соединение страны к контакту.
                join joinedCountry in _dbContext.Countries
                    on contact?.CityId equals joinedCountry.Id
                    into unitCountries

                from country in unitCountries.DefaultIfEmpty()

                    // Левое соединение аккаунта к пользователю.
                join joinedAccount in await _dbContext.Accounts.ToListAsync()
                    on sysAdminUnit.ContactId equals joinedAccount.Id
                    into unitAccounts

                from account in unitAccounts.DefaultIfEmpty()

                    // Левое соединение типа адреса к контакту.
                join joinedAddressType in await _dbContext.AddressTypes.ToListAsync()
                    on account?.AddressTypeId equals joinedAddressType.Id
                    into unitAddressTypes

                from addressType in unitAddressTypes.DefaultIfEmpty()

                select sysAdminUnit;

            return sysAdminUnits;
        }

        /// <summary>
        /// Находит пользователя по идентификатору. Если не найден, то пробрасывается исключение.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        private async Task<SysAdminUnit> FindUnitByIdAsync(Guid id)
        {
            var sysAdminUnit = await _dbContext.SysAdminUnits.FindAsync(id);

            if (sysAdminUnit == null)
            {
                throw new ArgumentException($"По данному идентификатору {id} ничего не найдено");
            }

            return sysAdminUnit;
        }
    }
}
