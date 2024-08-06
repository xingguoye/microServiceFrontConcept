using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.Commands.Api.Controllers.Common;
using Test.Commands.Application.Entities.Test.Commands.CreateTest;
using Test.Commands.Application.Entities.Test.Commands.DeleteTest;
using Test.Commands.Application.Entities.Test.Commands.UpdateTest;
using Test.Commands.Application.Entities.Test.Dtos;

namespace Test.Commands.Api.Controllers.Test
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ApiControllerBase
    {
        public TestController(ILogger<ApiControllerBase> logger, IMediator mediator, IMapper mapper) : base(logger, mediator, mapper)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TestCreateDto testDto)
        {
            try
            {
                CreateTestCommand createTestCommand = new CreateTestCommand() { NewTest = testDto };
                var result = await _mediator.Send(createTestCommand);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TestDto testDto)
        {
            try
            {
                UpdateTestCommand createTestCommand = new UpdateTestCommand() { UpdateTest = testDto };
                var result = await _mediator.Send(createTestCommand);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                DeleteTestCommand deleteTestCommand = new DeleteTestCommand() { DeleteTest = new TestDeleteDto() { Id = id  } };
                var result = await _mediator.Send(deleteTestCommand);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
