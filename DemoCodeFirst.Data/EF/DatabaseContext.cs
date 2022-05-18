using DemoCodeFirst.Data.Configuration;
using DemoCodeFirst.Data.Entities;
using DemoCodeFirst.Data.Extension;
using Microsoft.EntityFrameworkCore;

namespace DemoCodeFirst.Data.EF
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new StateConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());

            builder.Seed();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
