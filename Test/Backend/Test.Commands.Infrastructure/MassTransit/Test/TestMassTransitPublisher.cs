using MassTransit;
using Test.Commands.Infrastructure.MassTransit.Common;
using Test.Domain.Entities.Test;

namespace Test.Commands.Infrastructure.MassTransit.Test
{
    public class TestMassTransitPublisher : MassTransitPublisher, ITestMassTransitPublisher
    {
        public TestMassTransitPublisher(IPublishEndpoint publishEndpoint) : base(publishEndpoint)
        {
        }

        public async Task publishCreate<RBTestCreate>(RBTestCreate testCreateDto)
        {
            await publishMessage(testCreateDto);
        }

        public async Task publishUpdate<RBTest>(RBTest testDto)
        {
            await publishMessage(testDto);
        }

        public async Task publishDelete<RBTestDelete>(RBTestDelete testCreateDto)
        {
            await publishMessage(testCreateDto);
        }
    }
}
