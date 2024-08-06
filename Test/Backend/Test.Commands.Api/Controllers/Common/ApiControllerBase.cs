using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Test.Commands.Api.Controllers.Common
{
    public class ApiControllerBase : ControllerBase
    {
        protected readonly ILogger<ApiControllerBase> _logger;
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        public ApiControllerBase(ILogger<ApiControllerBase> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
