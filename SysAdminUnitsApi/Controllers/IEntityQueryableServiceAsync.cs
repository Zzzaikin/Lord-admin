using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SysAdminUnitsApi.Models;

namespace Norbit.Crm.Zaikin.SysAdminUnitsApi.Controllers
{
    /// <summary>
    /// Интерфейс контроллера запрашиваемых сущностей.
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// </summary>
    public interface IEntityQueryableServiceAsync<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Возвращает из базы данных все сущности. Есть ограничение по количеству записей в выборке, равное 1000. 
        /// Поддерживает пагинацию.
        /// </summary>
        /// <param name="count">Количество сущностей.</param>
        /// <param name="from">Индекс смещения выборки.</param>
        /// <returns>Статус выполнения запроса со всеми сущностями.</returns>
        Task<IActionResult> GetEntities(int count = 1000, int from = 0);

        /// <summary>
        /// Возвращает сущность по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Статус выполнения запроса с сущностью, найденной по идентификатору.</returns>
        Task<IActionResult> GetEntityById(Guid id);

        /// <summary>
        /// Создаёт сущность.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Статус выполнения запроса с добавденной сущностью.</returns>
        Task<IActionResult> InsertEntity(TEntity entity);

        /// <summary>
        /// Обновляет сущность.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Статус выполнения запроса с обновлённой сущностью.</returns>
        Task<IActionResult> UpdateEntity(TEntity entity);

        /// <summary>
        /// Удаляет Сущность из БД.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Статус выполнения запроса с идентификатором удалённой сущности.</returns>
        Task<IActionResult> DeleteEntity(Guid id);
    }
}
