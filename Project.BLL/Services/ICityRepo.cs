using System.Linq.Expressions;

namespace Project.BLL.Services
{
    public interface ICityRepo
    {
        Task<IEnumerable<City>> GetAsync(Expression<Func<City, bool>>? filter = null);
    }
}
