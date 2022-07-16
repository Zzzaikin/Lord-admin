using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysAdminUnitsApi.Models
{
    /// <summary>
    /// Город.
    /// </summary>
    [Table("City", Schema = "dbo")]
    public class City : BaseEntity
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
    }
}
