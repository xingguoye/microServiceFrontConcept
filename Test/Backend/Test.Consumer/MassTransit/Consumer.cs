using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Consumer.MassTransit
{
    public class Consumer
    {
        protected readonly IConfiguration _config;
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        public Consumer(IConfiguration config, IMediator mediator, IMapper mapper) {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
