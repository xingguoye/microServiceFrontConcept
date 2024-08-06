using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Test.Consumer.Application.Entities.Test.Commands.DeleteTest;
using Test.Consumer.Application.Entities.Test.Dtos;
using Test.Domain.RabbitMQ;

namespace Consumer.MassTransit
{
    public class TestDeleteDtoConsumer : Consumer, IConsumer<RBTestDelete>
    {
        public TestDeleteDtoConsumer(IConfiguration config, IMediator mediator, IMapper mapper) : base(config, mediator, mapper)
        {
        }

        public async Task Consume(ConsumeContext<RBTestDelete> context)
        {
            try
            {
                var result = await _mediator.Send(new DeleteTestCommand() { DeleteTest = _mapper.Map<TestDeleteDto>(context.Message) });
            }
            catch (Exception ex)
            {
            }
        }
    }
}
