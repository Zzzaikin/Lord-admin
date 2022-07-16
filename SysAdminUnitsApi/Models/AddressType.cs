using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysAdminUnitsApi.Models
{
    /// <summary>
    /// Тип адреса.
    /// </summary>
    [Table("AddressType", Schema = "dbo")]
    public class AddressType : BaseEntity
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
    }
}
