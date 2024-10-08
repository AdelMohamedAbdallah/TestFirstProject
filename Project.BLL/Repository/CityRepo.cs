using System.Linq.Expressions;

namespace Project.BLL.Repository
{
    public class CityRepo : ICityRepo
    {
        private readonly ApplicationDbContext db;

        public CityRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<City>> GetAsync(Expression<Func<City, bool>>? filter = null)
        {
            if (filter != null)
                return await db.Cities.AsNoTracking().Where(filter).Include(dis => dis.Country).ToListAsync();
            return await db.Cities.AsNoTracking().Include(dis => dis.Country).ToListAsync();
        }
    }
}
