using System.Linq.Expressions;

namespace Project.BLL.Services
{
    public interface IDepartmentRepo
    {
        Task<IEnumerable<Department>> GetAsync(Expression<Func<Department, bool>>? filter = null);
        Task<Department> GetByAsync(Expression<Func<Department, bool>> filter);
        Task CreateDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(Department department);
        Task UpdateDepartmentAsync(Department department);
    }
}


