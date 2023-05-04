using Database.Models;
using System.Data.Entity;

namespace Database.Context
{
    public partial class IsLibraryContext : DbContext
    {
        public IsLibraryContext() : base(@"data source=.\SQLEXPRESS;initial catalog=Library;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<PublishingHouse> PublishingHouses { get; set; }
        public virtual DbSet<Reader> Readers { get; set; }
        public virtual DbSet<Relic> Relics { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Writer> Writers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
