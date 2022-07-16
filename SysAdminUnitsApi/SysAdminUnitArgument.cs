using Microsoft.AspNetCore.Mvc;
using SysAdminUnitsApi.Models;
using System;

namespace SysAdminUnitsApi
{
    /// <summary>
    /// Валидатор параметров объекта SysAdminUnit.
    /// </summary>
    public static class SysAdminUnitArgument
    {
        /// <summary>
        /// Валидирует экземпляр SysAdminUnit.
        /// </summary>
        /// <param name="sysAdminUnit">Валидируемый экземпляр SysAdminUnit.</param>
        /// <param name="validatingNameAndPassword">Проверять имя и пароль.</param>
        /// <returns>Объект статуса выполнения запроса.</returns>
        public static IActionResult ValidateSysAdminUnit(SysAdminUnit sysAdminUnit, bool validatingNameAndPassword = true)
        {
            if (validatingNameAndPassword)
            {

                if (string.IsNullOrEmpty(sysAdminUnit.Name))
                {
                    return new BadRequestObjectResult($"{nameof(sysAdminUnit.Name)} не может быть null или пустым.");
                }

                if (string.IsNullOrEmpty(sysAdminUnit.UserPassword))
                {
                    return new BadRequestObjectResult($"{nameof(sysAdminUnit.UserPassword)} не может быть null или пустым");
                }
            }

            if (sysAdminUnit.ParentRoleId == Guid.Empty)
            {
                return new BadRequestObjectResult($"{nameof(sysAdminUnit.ParentRoleId)} не может быть пустым.");
            }

            return null;
        }
    }
}
