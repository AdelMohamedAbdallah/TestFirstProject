using System.Linq.Expressions;

namespace Project.BLL.Repository
{
    public class DistrictRepo : IDistrictRepo
    {
        private readonly ApplicationDbContext db;

        public DistrictRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<District>> GetAsync(Expression<Func<District, bool>>? filter = null)
        {
            if (filter != null)
                return await db.Districts.AsNoTracking().Where(filter).Include(dis => dis.City).ToListAsync();
            return await db.Districts.AsNoTracking().Include(dis => dis.City).ToListAsync();
        }
    }
}
