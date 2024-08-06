using Microsoft.Extensions.Configuration;
using Test.Domain.Entities.Test;

namespace Test.Queries.Infrastructure.Repositories.Test
{
    public class TestQueryRepository : QueryRepository<TestEntity>, ITestQueryRepository
    {
        public TestQueryRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
