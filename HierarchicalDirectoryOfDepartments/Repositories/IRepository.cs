namespace HierarchicalDirectoryOfDepartments.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();

        Task AddAsync(T item);

        Task AddListAsync(List<T> entityes);

        Task UpdateAsync(T item);

        Task DeleteAsync(T item);

        Task DeleteAllAsync();
    }
}
