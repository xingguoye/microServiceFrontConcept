using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.Queries.Application.Entities.Test.GetAllTestsQuery;

namespace Test.Queries.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ApiControllerBase
    {
        public TestController(ILogger<TestController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _mediator.Send(new GetAllTestsQueryRequest());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
