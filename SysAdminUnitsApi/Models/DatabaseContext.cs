using Microsoft.EntityFrameworkCore;

namespace SysAdminUnitsApi.Models
{
    /// <summary>
    /// Контекст базы данных.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Пользователи Creatio.
        /// </summary>
        public DbSet<SysAdminUnit> SysAdminUnits { get; set; }

        /// <summary>
        /// Контакты.
        /// </summary>
        public  DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// Аккаунты.
        /// </summary>
        public  DbSet<Account> Accounts { get; set; }

        /// <summary>
        /// Должности.
        /// </summary>
        public DbSet<Job> Jobs { get; set; }

        /// <summary>
        /// Департаменты.
        /// </summary>
        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// Города.
        /// </summary>
        public DbSet<City> Cities { get; set; }

        /// <summary>
        /// Регионы.
        /// </summary>
        public DbSet<Region> Regions { get; set; }

        /// <summary>
        /// Страны.
        /// </summary>
        public DbSet<Country> Countries { get; set; }

        /// <summary>
        /// Типы адресов.
        /// </summary>
        public DbSet<AddressType> AddressTypes { get; set; }

        /// <summary>
        /// Культуры.
        /// </summary>
        public DbSet<SysCulture> Cultures { get; set; }

        /// <summary>
        /// Вызывает метод EnsureCreated.
        /// </summary>
        /// <param name="options">Опции для базы данных.</param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options)
        {
            Database.EnsureCreated();
        }
    }
}
