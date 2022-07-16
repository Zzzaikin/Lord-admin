using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysAdminUnitsApi.Models
{
    /// <summary>
    /// Должность.
    /// </summary>
    [Table("Job", Schema = "dbo")]
    public class Job : BaseEntity
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
    }
}
