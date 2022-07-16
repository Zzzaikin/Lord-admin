using System.ComponentModel.DataAnnotations.Schema;

namespace SysAdminUnitsApi.Models
{
    /// <summary>
    /// Культура.
    /// </summary>
    [Table("SysCulture", Schema = "dbo")]
    public class SysCulture : BaseEntity
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }
    }
}
