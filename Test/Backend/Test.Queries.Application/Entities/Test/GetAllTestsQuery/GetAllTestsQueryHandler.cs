using AutoMapper;
using Test.Domain.Entities.Test;
using Test.Queries.Application.Configuration.Queries;
using Test.Queries.Application.Entities.Test.Dtos;

namespace Test.Queries.Application.Entities.Test.GetAllTestsQuery
{
    public class GetAllTestsQueryHandler : BaseQueryHandler<GetAllTestsQueryRequest, TestResponse>
    {
        private readonly ITestQueryRepository _testQueryRepository;

        public GetAllTestsQueryHandler(ITestQueryRepository testQueryRepository, IMapper mapper) : base(mapper)
        {
            _testQueryRepository = testQueryRepository;
        }

        public override async Task<TestResponse> Handle(GetAllTestsQueryRequest request, CancellationToken cancellationToken)
        {
            string sql = "Select * From dbo.TestEntity";

            List<TestEntity> resultQuery = await _testQueryRepository.SendQuery(sql);

            List<TestDto> resultReturn = resultQuery.Select(t => _mapper.Map<TestDto>(t)).ToList();

            TestResponse result = new TestResponse()
            {
                Items = resultReturn
            };

            return result;
        }
    }
}
