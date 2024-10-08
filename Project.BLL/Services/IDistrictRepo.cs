using System.Linq.Expressions;

namespace Project.BLL.Services
{
    public interface IDistrictRepo
    {
        Task<IEnumerable<District>> GetAsync(Expression<Func<District, bool>>? filter = null);
    }
}
