using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Test.Consumer.Application.Entities.Test.Commands.CreateTest;
using Test.Consumer.Application.Entities.Test.Dtos;
using Test.Domain.RabbitMQ;

namespace Consumer.MassTransit
{
    public class TestCreateDtoConsumer : Consumer, IConsumer<RBTestCreate>
    {
        public TestCreateDtoConsumer(IConfiguration config, IMediator mediator, IMapper mapper) : base(config, mediator, mapper)
        {
        }

        public async Task Consume(ConsumeContext<RBTestCreate> context)
        {
            try
            {
                var result = await _mediator.Send(new CreateTestCommand() { NewTest = _mapper.Map<TestCreateDto>( context.Message) });
            }
            catch (Exception ex)
            {
            }
        }
    }
}
