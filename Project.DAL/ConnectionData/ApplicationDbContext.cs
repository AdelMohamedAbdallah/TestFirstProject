using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using Project.DAL.EntitiesConfiguration;

namespace Project.DAL.ConnectionData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DepartmentTypeConfiguration).Assembly);
        }
    }
}
