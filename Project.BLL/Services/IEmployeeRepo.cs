using System.Linq.Expressions;

namespace Project.BLL.Services
{
    public interface IEmployeeRepo
    {
        Task<IEnumerable<Employee>> GetAsync(Expression<Func<Employee, bool>>? filter = null);
        Task<Employee> GetByAsync(Expression<Func<Employee, bool>>? filter = null);
        Task CreateEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(Employee employee);
    }
}
