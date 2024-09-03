namespace Project.BLL.Repository
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly ApplicationDbContext db;
        public DepartmentRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Department>> GetAsync()
        {
            var data = db.Departments.AsNoTracking();
            return data;
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            var data = await db.Departments.FindAsync(id);

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
