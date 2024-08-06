using Test.Commands.Application.Configuration.Commands;
using Test.Commands.Application.Entities.Test.Dtos;

namespace Test.Commands.Application.Entities.Test.Commands.CreateTest
{
    public class CreateTestCommand : BaseCommand<TestResponse>
    {
        public TestCreateDto NewTest { get; set; }
    }
}
