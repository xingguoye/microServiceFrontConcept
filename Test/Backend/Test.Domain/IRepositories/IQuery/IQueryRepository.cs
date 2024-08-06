namespace Test.Domain.IRepositories.IQuery
{
    public interface IQueryRepository<T> where T : class
    {
        Task<List<T>> SendQuery(string query);
    }
}
