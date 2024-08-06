using MediatR;

namespace Test.Commands.Application.Configuration.Commands
{
    public interface IBaseCommand : IRequest
    {
    }

    public interface IBaseCommand<T> : IRequest<T>
    {
    }
}
