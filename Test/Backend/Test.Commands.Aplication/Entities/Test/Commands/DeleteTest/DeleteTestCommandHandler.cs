using AutoMapper;
using Test.Commands.Application.Configuration.Commands;
using Test.Commands.Application.Entities.Test.Dtos;
using Test.Domain.Entities.Test;
using Test.Domain.RabbitMQ;

namespace Test.Commands.Application.Entities.Test.Commands.DeleteTest
{
    public class DeleteTestCommandHandler : BaseCommandHandler<DeleteTestCommand, TestResponse>
    {
        public readonly ITestCommandRepository _testCommandRepository;
        public readonly ITestMassTransitPublisher _testMassTransitPublisher;

        public DeleteTestCommandHandler(ITestCommandRepository testCommandRepository, ITestMassTransitPublisher testMassTransitPublisher, IMapper mapper) : base(mapper)
        {
            _testCommandRepository = testCommandRepository;
            _testMassTransitPublisher = testMassTransitPublisher;
        }

        public override async Task<TestResponse> Handle(DeleteTestCommand request, CancellationToken cancellationToken)
        {
            var testEntity = _mapper.Map<TestEntity>(request.DeleteTest);

            var deleteTestEntity = await _testCommandRepository.DeleteAsync(testEntity);

            RBTestDelete deleteRBTestDeleteDto = _mapper.Map<RBTestDelete>(request.DeleteTest);

            await _testMassTransitPublisher.publishDelete(deleteRBTestDeleteDto);

            return new TestResponse() { Success = deleteTestEntity > 0 };
        }
    }
}
