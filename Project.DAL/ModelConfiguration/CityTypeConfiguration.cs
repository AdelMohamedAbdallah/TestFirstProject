using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.DAL.Entities;

namespace Project.DAL.EntitiesConfiguration
{
    public class CityTypeConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(dep => dep.City_Id);

            builder.Property(dep => dep.City_Name).HasMaxLength(30);

            builder.HasOne(dis => dis.Country)
                .WithMany(cit => cit.Cities)
                .HasForeignKey(dis => dis.Country_Id)
                .HasConstraintName("FK_Country_Id")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable("Cities");
        }
    }
}
