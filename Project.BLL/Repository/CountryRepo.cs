using System.Linq.Expressions;

namespace Project.BLL.Repository
{
    public class CountryRepo : ICountryRepo
    {
        private readonly ApplicationDbContext db;

        public CountryRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Country>> GetAsync(Expression<Func<Country, bool>>? filter = null)
        {
            if (filter != null)
                return await db.Countries.AsNoTracking().Where(filter).ToListAsync();
            return await db.Countries.AsNoTracking().ToListAsync();
        }
    }
}
