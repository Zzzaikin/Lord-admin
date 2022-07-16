using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysAdminUnitsApi.Models
{
    /// <summary>
    /// Пользователь Creatio.
    /// </summary>
    [Table("SysAdminUnit", Schema = "dbo")]
    public class SysAdminUnit : BaseEntity
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Родительская роль.
        /// </summary>
        public Guid? ParentRoleId { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string UserPassword { get; set; }

        /// <summary>
        /// Тип.
        /// </summary>
        [Column("SysAdminUnitTypeValue")]
        public int UnitType { get; set; }

        /// <summary>
        /// Идентификатор контакта.
        /// </summary>
        public Guid? ContactId { get; set; }

        /// <summary>
        /// Контакт.
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// Идентификатор аккаунта.
        /// </summary>
        public Guid? AccountId { get; set; }

        /// <summary>
        /// Аккаунт.
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// Активность.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Идентификатор культуры.
        /// </summary>
        public Guid? SysCultureId { get; set; }

        /// <summary>
        /// Культура.
        /// </summary>
        public SysCulture Culture { get; set; }
    }
}
