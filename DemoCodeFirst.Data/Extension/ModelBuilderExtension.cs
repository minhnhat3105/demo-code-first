using DemoCodeFirst.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoCodeFirst.Data.Extension
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country()
                {
                    Id = 1,
                    Name = "bbb",
                    Status = true
                },
                new Country()
                {
                    Id = 2,
                    Name = "kkk",
                    Status = true
                },
                new Country()
                {
                    Id = 3,
                    Name = "zzz",
                    Status = true
                });

            builder.Entity<State>().HasData(
                new State()
                {
                    Id = 1,
                    Name = "ddd",
                    CountryId = 1,
                    Status = true
                },
                new State()
                {
                    Id = 2,
                    Name = "eee",
                    CountryId = 2,
                    Status = true
                },
                new State()
                {
                    Id = 3,
                    Name = "fff",
                    CountryId = 3,
                    Status = true
                });

            builder.Entity<City>().HasData(
                new City()
                {
                    Id = 1,
                    Name = "ABC",
                    StateId = 1,
                    Status = true
                },
                new City()
                {
                    Id = 2,
                    Name = "XYZ",
                    StateId = 2,
                    Status = true
                },
                new City()
                {
                    Id = 3,
                    Name = "MLB",
                    StateId = 3,
                    Status = true
                });
        }
    }
}
