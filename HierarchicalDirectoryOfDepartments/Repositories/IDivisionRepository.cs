using HierarchicalDirectoryOfDepartments.Models.HierarhyModels;

namespace HierarchicalDirectoryOfDepartments.Repositories
{
    public interface IDivisionRepository: IRepository<Division>
    {
        Task<Division?> GetAsync(Guid guid);
    }
}
