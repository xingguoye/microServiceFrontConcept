namespace Test.Consumer.Application.Configuration.Commands
{
    public abstract class BaseCommand : IBaseCommand
    {
    }

    public abstract class BaseCommand<T> : IBaseCommand<T>
    {
    }
}
