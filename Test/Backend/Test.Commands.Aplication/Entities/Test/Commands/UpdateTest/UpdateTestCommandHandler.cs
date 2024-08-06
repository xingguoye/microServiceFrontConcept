using AutoMapper;
using Test.Commands.Application.Configuration.Commands;
using Test.Commands.Application.Entities.Test.Dtos;
using Test.Domain.Entities.Test;
using Test.Domain.RabbitMQ;

namespace Test.Commands.Application.Entities.Test.Commands.UpdateTest
{
    public class UpdateTestCommandHandler : BaseCommandHandler<UpdateTestCommand, TestResponse>
    {
        public readonly ITestCommandRepository _testCommandRepository;
        public readonly ITestMassTransitPublisher _testMassTransitPublisher;

        public UpdateTestCommandHandler(ITestCommandRepository testCommandRepository, ITestMassTransitPublisher testMassTransitPublisher, IMapper mapper) : base(mapper)
        {
            _testCommandRepository = testCommandRepository;
            _testMassTransitPublisher = testMassTransitPublisher;
        }

        public override async Task<TestResponse> Handle(UpdateTestCommand request, CancellationToken cancellationToken)
        {
            var testEntity = _mapper.Map<TestEntity>(request.UpdateTest);

            var updateTestEntity = await _testCommandRepository.UpdateAsync(testEntity);

            RBTest updateRBTestDto = _mapper.Map<RBTest>(request.UpdateTest);

            await _testMassTransitPublisher.publishUpdate(updateRBTestDto);

            return new TestResponse() { Success = updateTestEntity > 0 };
        }
    }
}
