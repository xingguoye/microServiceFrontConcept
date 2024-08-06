using AutoMapper;
using Test.Consumer.Application.Configuration.Commands;
using Test.Consumer.Application.Entities.Test.Dtos;
using Test.Domain.Entities.Test;

namespace Test.Consumer.Application.Entities.Test.Commands.CreateTest
{
    public class CreateTestCommandHandler : BaseCommandHandler<CreateTestCommand, TestResponse>
    {
        public readonly ITestCommandRepository _testCommandRepository;

        public CreateTestCommandHandler(ITestCommandRepository testCommandRepository, IMapper mapper) : base(mapper)
        {
            _testCommandRepository = testCommandRepository;
        }

        public override async Task<TestResponse> Handle(CreateTestCommand request, CancellationToken cancellationToken)
        {
            TestResponse testResponse;
            try
            {
                TestEntity newTestEntity = _mapper.Map<TestEntity>(request.NewTest);

                var newTestEntityResult = await _testCommandRepository.AddAsync(newTestEntity);

                testResponse = new TestResponse() { Success = newTestEntityResult > 0 };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                testResponse = new TestResponse() { Success = false };
            }

            return testResponse;
        }
    }
}
