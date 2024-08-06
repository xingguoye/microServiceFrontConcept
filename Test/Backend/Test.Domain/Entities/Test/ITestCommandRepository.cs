using Test.Domain.IRepositories.ICommand;

namespace Test.Domain.Entities.Test
{
    public interface ITestCommandRepository : ICommandRepository<TestEntity>
    {
    }
}
