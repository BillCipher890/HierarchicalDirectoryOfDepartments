using HierarchicalDirectoryOfDepartments.Models.HierarhyModels;

namespace HierarchicalDirectoryOfDepartments.Repositories
{
    public interface IDepartmentRepository: IRepository<Department>
    {
        Task<Department?> GetAsync(Guid guid);
    }
}
