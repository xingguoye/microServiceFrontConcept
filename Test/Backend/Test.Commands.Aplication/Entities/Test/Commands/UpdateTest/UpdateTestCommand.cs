using Test.Commands.Application.Configuration.Commands;
using Test.Commands.Application.Entities.Test.Dtos;

namespace Test.Commands.Application.Entities.Test.Commands.UpdateTest
{
    public class UpdateTestCommand : BaseCommand<TestResponse>
    {
        public TestDto UpdateTest { get; set; }
    }
}
