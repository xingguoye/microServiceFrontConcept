using MediatR;

namespace Test.Consumer.Application.Configuration.Commands
{
    public interface IBaseCommand : IRequest
    {
    }

    public interface IBaseCommand<T> : IRequest<T>
    {
    }
}
