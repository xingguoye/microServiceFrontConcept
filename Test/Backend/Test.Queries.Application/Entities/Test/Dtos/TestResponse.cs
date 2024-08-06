using Test.Queries.Application.Configuration.Dtos;

namespace Test.Queries.Application.Entities.Test.Dtos
{
    public class TestResponse : BaseResponse<TestDto>
    {
        public List<TestDto> Items { get; set; } = new List<TestDto>();
    }
}
