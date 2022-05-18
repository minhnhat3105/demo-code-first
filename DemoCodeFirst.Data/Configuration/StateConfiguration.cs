using DemoCodeFirst.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoCodeFirst.Data.Configuration
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasKey(state => state.Id);
            builder.HasOne(country => country.Country).WithMany(state => state.States).HasForeignKey(state => state.CountryId);
            builder.Property(state => state.Name).HasMaxLength(100).IsRequired();
            builder.Property(state => state.Status).IsRequired();
        }
    }
}
