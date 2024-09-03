namespace Project.BLL.Services
{
    public interface IDepartmentRepo
    {
        Task<IEnumerable<Department>> GetAsync();
        Task<Department> GetByIdAsync(int id);
        Task CreateDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(Department department);
        Task UpdateDepartmentAsync(Department department);
    }
}


