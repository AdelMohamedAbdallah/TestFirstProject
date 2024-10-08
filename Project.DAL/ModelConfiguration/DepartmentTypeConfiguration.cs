using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.DAL.Entities;
namespace Project.DAL.EntitiesConfiguration
{
    public class DepartmentTypeConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(dep => dep.Department_Id);

            builder.Property(dep => dep.Department_Name).HasMaxLength(30);

            builder.Property(dep => dep.Department_Code).HasMaxLength(30);

            builder.HasIndex(dep => dep.Department_Name).IsUnique();

            builder.HasIndex(dep => dep.Department_Code).IsUnique();

            builder.ToTable("Departments");

        }
    }
}
