using System.Linq.Expressions;

namespace Project.BLL.Services
{
    public interface IEmployeeRepo
    {
        Task<IEnumerable<Employee>> GetAsync(Expression<Func<Employee, bool>>? filter = null);
        Task<IEnumerable<Employee>> SearchAsync(Expression<Func<Employee, bool>> filter);
        Task<Employee> GetByAsync(Expression<Func<Employee, bool>>? filter = null);
        Task CreateEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(Employee employee);
        Task FinalDeleteAsync(Employee employee);
        Task ReturnEmployeeAsync(Employee employee);
    }
}
