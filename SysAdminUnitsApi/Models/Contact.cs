using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysAdminUnitsApi.Models
{
    /// <summary>
    /// Контакт.
    /// </summary>
    [Table("Contact", Schema = "dbo")]
    public class Contact : BaseEntity
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор должности.
        /// </summary>
        public Guid? JobId { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        public Job Job { get; set; }

        /// <summary>
        /// Заголовок должности.
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Идентификатор города.
        /// </summary>
        public Guid? CityId { get; set; }

        /// <summary>
        /// Город.
        /// </summary>
        public City City { get; set; }

        /// <summary>
        /// Идентификатор региона.
        /// </summary>
        public Guid? RegionId { get; set; }

        /// <summary>
        /// Регион.
        /// </summary>
        public Region Region { get; set; }

        /// <summary>
        /// Идентификатор страны.
        /// </summary>
        public Guid? CountryId { get; set; }

        /// <summary>
        /// Страна.
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// Идентификатор департамента.
        /// </summary>
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// Департамент.
        /// </summary>
        public Department Departament { get; set; }
    }
}
