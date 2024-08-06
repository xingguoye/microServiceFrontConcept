using AutoMapper;
using Test.Consumer.Application.Configuration.Commands;
using Test.Consumer.Application.Entities.Test.Dtos;
using Test.Domain.Entities.Test;

namespace Test.Consumer.Application.Entities.Test.Commands.UpdateTest
{
    public class UpdateTestCommandHandler : BaseCommandHandler<UpdateTestCommand, TestResponse>
    {
        public readonly ITestCommandRepository _testCommandRepository;

        public UpdateTestCommandHandler(ITestCommandRepository testCommandRepository, IMapper mapper) : base(mapper)
        {
            _testCommandRepository = testCommandRepository;
        }

        public override async Task<TestResponse> Handle(UpdateTestCommand request, CancellationToken cancellationToken)
        {
            var testEntity = _mapper.Map<TestEntity>(request.UpdateTest);

            var updateTestEntity = await _testCommandRepository.UpdateAsync(testEntity);

            return new TestResponse() { Success = updateTestEntity > 0 };
        }
    }
}
