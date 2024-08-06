using AutoMapper;
using MediatR;

namespace Test.Queries.Application.Configuration.Queries
{
    public abstract class BaseQueryHandler<T, R> : IRequestHandler<T, R> where T : BaseQueryRequest<R> where R : class
    {
        protected readonly IMapper _mapper;

        public BaseQueryHandler(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public virtual Task<R> Handle(T request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
