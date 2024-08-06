using Dapper;
using Microsoft.Extensions.Configuration;
using Test.Domain.IRepositories.IQuery;
using Test.Queries.Infrastructure.Data;

namespace Test.Queries.Infrastructure.Repositories.Test
{
    public class QueryRepository<T> : DbConnector, IQueryRepository<T> where T : class
    {
        public QueryRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<List<T>> SendQuery(string query)
        {
            using (var connection = CreateConnection())
            {
                return (await connection.QueryAsync<T>(query)).ToList();
            }
        }
    }
}
