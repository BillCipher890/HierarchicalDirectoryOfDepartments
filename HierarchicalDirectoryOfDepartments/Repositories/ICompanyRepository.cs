using HierarchicalDirectoryOfDepartments.Models.HierarhyModels;

namespace HierarchicalDirectoryOfDepartments.Repositories
{
    public interface ICompanyRepository: IRepository<Company>
    {
        Task<Company?> GetAsync(Guid guid);

        Task<List<Company>> GetAllIncludedAsync();
    }
}
