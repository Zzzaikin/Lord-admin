using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysAdminUnitsApi.Models
{
    /// <summary>
    /// Аккаунт.
    /// </summary>
    [Table("Account", Schema = "dbo")]
    public class Account : BaseEntity
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Сайт.
        /// </summary>
        public string Web { get; set; }

        /// <summary>
        /// Тип адреса.
        /// </summary>
        public Guid? AddressTypeId { get; set; }

        /// <summary>
        /// Адресс.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Тип адреса.
        /// </summary>
        public AddressType AddressType { get; set; } 

        /// <summary>
        /// Компетентность.
        /// </summary>
        public int Completeness { get; set; }
    }
}
