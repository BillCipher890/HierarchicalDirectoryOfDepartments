using HierarchicalDirectoryOfDepartments.Models.HierarhyModels;
using Microsoft.EntityFrameworkCore;

namespace HierarchicalDirectoryOfDepartments.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        private readonly DbSet<Company> _dbSet;

        public CompanyRepository(ApplicationContext context) : base(context) 
        {
            _dbSet = context.Set<Company>();
        }

        public async Task<Company?> GetAsync(Guid guid)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.GUID == guid);
        }

        public async Task<List<Company>> GetAllIncludedAsync()
        {
            return await _dbSet.Include(c => c.Departments).ThenInclude(d => d.Divisions).ToListAsync();
        }
    }
}
