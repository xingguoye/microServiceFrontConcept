using Test.Consumer.Infrastructure.Data;
using Test.Domain.Entities.Test;

namespace Test.Consumer.Infrastructure.Repositories.Test
{
    public class TestCommandRepository : CommandRepository<TestEntity>, ITestCommandRepository
    {
        public TestCommandRepository(EFDataContext context) : base(context)
        {
        }
    }
}
