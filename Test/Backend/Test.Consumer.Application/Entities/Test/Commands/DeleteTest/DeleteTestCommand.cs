using Test.Consumer.Application.Configuration.Commands;
using Test.Consumer.Application.Entities.Test.Dtos;

namespace Test.Consumer.Application.Entities.Test.Commands.DeleteTest
{
    public class DeleteTestCommand : BaseCommand<TestResponse>
    {
        public TestDeleteDto DeleteTest { get; set; }
    }
}
