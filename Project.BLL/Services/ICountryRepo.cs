using System.Linq.Expressions;

namespace Project.BLL.Services
{
    public interface ICountryRepo
    {
        Task<IEnumerable<Country>> GetAsync(Expression<Func<Country, bool>>? filter = null);
    }
}
