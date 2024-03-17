using HierarchicalDirectoryOfDepartments.Models.HierarhyModels;
using Microsoft.EntityFrameworkCore;

namespace HierarchicalDirectoryOfDepartments.Repositories
{
    public class DivisionRepository : BaseRepository<Division>, IDivisionRepository
    {
        private readonly DbSet<Division> _dbSet;

        public DivisionRepository(ApplicationContext context) : base(context)
        {
            _dbSet = context.Set<Division>();
        }

        public async Task<Division?> GetAsync(Guid guid)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.GUID == guid);
        }
    }
}
