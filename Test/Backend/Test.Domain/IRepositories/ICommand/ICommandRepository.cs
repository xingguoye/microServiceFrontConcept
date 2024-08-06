namespace Test.Domain.IRepositories.ICommand
{
    public interface ICommandRepository<T> where T : class
    {
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}
