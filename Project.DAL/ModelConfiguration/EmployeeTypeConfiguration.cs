using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.DAL.Entities;

namespace Project.DAL.EntitiesConfiguration
{
    public class EmployeeTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(emp => emp.Employee_Id);

            builder.Property(emp => emp.Employee_Fname).HasMaxLength(30);

            builder.Property(emp => emp.Employee_Lname).HasMaxLength(30);

            builder.Property(emp => emp.Employee_Email).HasMaxLength(50);

            builder.HasIndex(emp => emp.Employee_Email).IsUnique();

            builder.Property(emp => emp.Employee_Email).IsRequired(false);

            builder.Property(emp => emp.Employee_Phone).HasMaxLength(20);

            builder.HasIndex(emp => emp.Employee_Phone).IsUnique();

            builder.Property(emp => emp.Address).HasMaxLength(100);

            builder.Property(emp => emp.Employee_Salary).HasDefaultValue(4000).HasPrecision(10, 2);

            builder.ToTable(emp => emp.HasCheckConstraint("CK_Salary", "Employee_Salary between 4000 and 10000"));

            builder.Property(emp => emp.IsActive).HasDefaultValue(true);

            builder.Property(emp => emp.IsDeleted).HasDefaultValue(false);

            builder.Property(emp => emp.CreationDate).HasDefaultValue(DateTime.Now);

            builder.HasOne(emp => emp.Department)
                .WithMany(emp => emp.Employees)
                .HasForeignKey(emp => emp.Department_Id)
                .HasConstraintName("FK_Department_Id")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(emp => emp.District)
                .WithMany(dis => dis.Employees)
                .HasForeignKey(emp => emp.District_Id)
                .HasConstraintName("FK_District_Id")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable("Employees");
        }
    }
}
