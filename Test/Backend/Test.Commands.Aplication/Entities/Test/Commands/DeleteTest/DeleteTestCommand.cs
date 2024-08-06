using Test.Commands.Application.Configuration.Commands;
using Test.Commands.Application.Entities.Test.Dtos;

namespace Test.Commands.Application.Entities.Test.Commands.DeleteTest
{
    public class DeleteTestCommand : BaseCommand<TestResponse>
    {
        public TestDeleteDto DeleteTest { get; set; }
    }
}
