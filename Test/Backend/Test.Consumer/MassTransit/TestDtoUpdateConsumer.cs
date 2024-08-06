using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Test.Consumer.Application.Entities.Test.Commands.UpdateTest;
using Test.Consumer.Application.Entities.Test.Dtos;
using Test.Domain.RabbitMQ;

namespace Consumer.MassTransit
{
    public class TestDtoUpdateConsumer : Consumer, IConsumer<RBTest>
    {
        public TestDtoUpdateConsumer(IConfiguration config, IMediator mediator, IMapper mapper) : base(config, mediator, mapper)
        {
        }

        public async Task Consume(ConsumeContext<RBTest> context)
        {
            try
            {
                var result = await _mediator.Send(new UpdateTestCommand() { UpdateTest = _mapper.Map<TestDto>(context.Message) });
            }
            catch (Exception ex)
            {
            }
        }
    }
}
