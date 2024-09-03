using System.Linq.Expressions;

namespace Project.BLL.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        ApplicationDbContext db;

        public EmployeeRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Employee>> GetAsync(Expression<Func<Employee, bool>>? filter = null)
        {
            if (filter is null)
                return await db.Employees.AsNoTracking().ToListAsync();
            return await db.Employees.AsNoTracking().Where(filter).ToListAsync();
        }

        public async Task<Employee> GetByAsync(Expression<Func<Employee, bool>> filter)
        {
            var data = await db.Employees.Where(filter).FirstOrDefaultAsync();

            if (data == null)
                throw new ArgumentNullException("No Result");
            return data;
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            await db.Employees.AddAsync(employee);
            await db.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            employee.IsUpdated = true;
            employee.UpdatedDate = DateTime.Now;
            db.Entry(employee).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            employee.IsDeleted = true;
            employee.DeletedDate = DateTime.Now;
            await db.SaveChangesAsync();
        }
    }
}
