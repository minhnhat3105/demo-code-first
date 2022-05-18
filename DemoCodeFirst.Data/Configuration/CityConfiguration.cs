using DemoCodeFirst.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoCodeFirst.Data.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(city => city.Id);
            builder.HasOne(state => state.State).WithMany(city => city.cities).HasForeignKey(city => city.StateId);
            builder.Property(city => city.Name).HasMaxLength(100).IsRequired();
            builder.Property(city => city.Status).IsRequired();
        }
    }
}
