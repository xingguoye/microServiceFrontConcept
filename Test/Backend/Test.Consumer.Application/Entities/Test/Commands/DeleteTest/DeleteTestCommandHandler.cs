using AutoMapper;
using Test.Consumer.Application.Configuration.Commands;
using Test.Consumer.Application.Entities.Test.Dtos;
using Test.Domain.Entities.Test;

namespace Test.Consumer.Application.Entities.Test.Commands.DeleteTest
{
    public class DeleteTestCommandHandler : BaseCommandHandler<DeleteTestCommand, TestResponse>
    {
        public readonly ITestCommandRepository _testCommandRepository;

        public DeleteTestCommandHandler(ITestCommandRepository testCommandRepository, IMapper mapper) : base(mapper)
        {
            _testCommandRepository = testCommandRepository;
        }

        public override async Task<TestResponse> Handle(DeleteTestCommand request, CancellationToken cancellationToken)
        {
            var testEntity = _mapper.Map<TestEntity>(request.DeleteTest);

            var deleteTestEntity = await _testCommandRepository.DeleteAsync(testEntity);

            return new TestResponse() { Success = deleteTestEntity > 0 };
        }
    }
}
