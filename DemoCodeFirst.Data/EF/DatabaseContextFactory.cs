using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DemoCodeFirst.Data.EF
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DemoCodeFirst"); 
            var optionBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new DatabaseContext(optionBuilder.Options);
        }
    }
}
