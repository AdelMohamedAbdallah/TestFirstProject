using System.Linq.Expressions;

namespace Project.BLL.Repository
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly ApplicationDbContext db;
        public DepartmentRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Department>> GetAsync(Expression<Func<Department, bool>>? filter = null)
        {
            if (filter is null)
                return await db.Departments.AsNoTracking()
                                           .ToListAsync();

            return await db.Departments.AsNoTracking()
                                     .Where(filter)
                                     .ToListAsync();
        }

        public async Task<Department> GetByAsync(Expression<Func<Department, bool>> filter)
        {
            var data = await db.Departments.AsNoTracking()
                                         .Where(filter)
                                         .FirstOrDefaultAsync();

            if (data == null)
                throw new ArgumentNullException("No Result");
            return data;
        }

        public async Task CreateDepartmentAsync(Department department)
        {
            await db.Departments.AddAsync(department);
            await db.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(Department department)
        {
            db.Departments.Remove(department);
            await db.SaveChangesAsync();
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            db.Entry(department).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

    }
}
