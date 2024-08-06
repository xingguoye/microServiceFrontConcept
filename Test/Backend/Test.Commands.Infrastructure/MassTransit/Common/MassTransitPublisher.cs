using MassTransit;

namespace Test.Commands.Infrastructure.MassTransit.Common
{
    public abstract class MassTransitPublisher
    {
        protected readonly IPublishEndpoint _publishEndpoint;

        public MassTransitPublisher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task publishMessage<T>(T data)
        {
            await _publishEndpoint.Publish(data);
        }
    }
}
