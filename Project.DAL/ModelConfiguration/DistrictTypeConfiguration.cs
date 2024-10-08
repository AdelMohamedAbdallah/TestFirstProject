using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.DAL.Entities;

namespace Project.DAL.EntitiesConfiguration
{
    public class DistrictTypeConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasKey(dep => dep.District_Id);

            builder.Property(dep => dep.District_Name).HasMaxLength(30);

            builder.HasOne(dis => dis.City)
                .WithMany(cit => cit.Districts)
                .HasForeignKey(dis => dis.City_Id)
                .HasConstraintName("FK_City_Id")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable("Districts");

        }
    }
}
