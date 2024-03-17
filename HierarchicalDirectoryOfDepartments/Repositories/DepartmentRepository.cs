using HierarchicalDirectoryOfDepartments.Models.HierarhyModels;
using Microsoft.EntityFrameworkCore;

namespace HierarchicalDirectoryOfDepartments.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        private readonly DbSet<Department> _dbSet;

        public DepartmentRepository(ApplicationContext context) : base(context)
        {
            _dbSet = context.Set<Department>();
        }

        public async Task<Department?> GetAsync(Guid guid)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.GUID == guid);
        }
    }
}
