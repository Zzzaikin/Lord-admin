using System.ComponentModel.DataAnnotations.Schema;

namespace SysAdminUnitsApi.Models
{
    /// <summary>
    /// Регион.
    /// </summary>
    [Table("Country", Schema = "dbo")]
    public class Country : BaseEntity
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
    }
}
