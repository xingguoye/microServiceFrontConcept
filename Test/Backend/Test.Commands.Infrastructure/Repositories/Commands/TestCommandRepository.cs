using Test.Commands.Infrastructure.Data;
using Test.Domain.Entities.Test;

namespace Test.Commands.Infrastructure.Repositories.Commands
{
    public class TestCommandRepository : CommandRepository<TestEntity>, ITestCommandRepository
    {
        public TestCommandRepository(EFDataContext context) : base(context)
        {
        }
    }
}
