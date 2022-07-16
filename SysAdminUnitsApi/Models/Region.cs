using System.ComponentModel.DataAnnotations.Schema;

namespace SysAdminUnitsApi.Models
{
    /// <summary>
    /// Регион.
    /// </summary>
    [Table("Region", Schema = "dbo")]
    public class Region : BaseEntity
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
    }
}
