namespace Test.Domain.Entities.Test
{
    public interface ITestMassTransitPublisher
    {
        Task publishCreate<T>(T data);
        Task publishUpdate<T>(T data);
        Task publishDelete<T>(T data);
    }
}
