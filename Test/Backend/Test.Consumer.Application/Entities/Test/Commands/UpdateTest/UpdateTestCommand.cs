using Test.Consumer.Application.Configuration.Commands;
using Test.Consumer.Application.Entities.Test.Dtos;

namespace Test.Consumer.Application.Entities.Test.Commands.UpdateTest
{
    public class UpdateTestCommand : BaseCommand<TestResponse>
    {
        public TestDto UpdateTest { get; set; }
    }
}
