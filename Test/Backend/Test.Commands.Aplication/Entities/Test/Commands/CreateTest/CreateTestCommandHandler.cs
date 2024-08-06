using AutoMapper;
using Test.Commands.Application.Configuration.Commands;
using Test.Commands.Application.Entities.Test.Dtos;
using Test.Domain.Entities.Test;
using Test.Domain.RabbitMQ;

namespace Test.Commands.Application.Entities.Test.Commands.CreateTest
{
    public class CreateTestCommandHandler : BaseCommandHandler<CreateTestCommand, TestResponse>
    {
        public readonly ITestCommandRepository _testCommandRepository;
        public readonly ITestMassTransitPublisher _testMassTransitPublisher;

        public CreateTestCommandHandler(ITestCommandRepository testCommandRepository, ITestMassTransitPublisher testMassTransitPublisher, IMapper mapper) : base(mapper)
        {
            _testCommandRepository = testCommandRepository;
            _testMassTransitPublisher = testMassTransitPublisher;
        }

        public override async Task<TestResponse> Handle(CreateTestCommand request, CancellationToken cancellationToken)
        {
            TestResponse testResponse;
            try
            {
                TestEntity newTestEntity = _mapper.Map<TestEntity>(request.NewTest);

                var newTestEntityResult = await _testCommandRepository.AddAsync(newTestEntity);

                RBTestCreate newRBTestCreateDto = _mapper.Map<RBTestCreate>(request.NewTest);

                await _testMassTransitPublisher.publishCreate(newRBTestCreateDto);

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
