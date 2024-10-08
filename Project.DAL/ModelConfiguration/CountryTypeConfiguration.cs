using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.DAL.Entities;

namespace Project.DAL.EntitiesConfiguration
{
    public class CountryTypeConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(dep => dep.Country_Id);

            builder.Property(dep => dep.Country_Name).HasMaxLength(30);

            builder.ToTable("Countries");

        }
    }
}
