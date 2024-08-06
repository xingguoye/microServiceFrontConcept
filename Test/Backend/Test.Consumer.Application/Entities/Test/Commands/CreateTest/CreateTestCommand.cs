using Test.Consumer.Application.Configuration.Commands;
using Test.Consumer.Application.Entities.Test.Dtos;

namespace Test.Consumer.Application.Entities.Test.Commands.CreateTest
{
    public class CreateTestCommand : BaseCommand<TestResponse>
    {
        public TestCreateDto NewTest { get; set; }
    }
}
