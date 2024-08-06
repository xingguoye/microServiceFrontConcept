using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Test.Queries.Api.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        public readonly ILogger<ApiControllerBase> _logger;
        public readonly IMediator _mediator;

        public ApiControllerBase(ILogger<ApiControllerBase> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
    }
}
