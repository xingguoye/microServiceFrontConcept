using MediatR;

namespace Test.Queries.Application.Configuration.Queries
{
    public abstract class BaseQueryRequest<T> : IRequest<T>
    {
    }
}
