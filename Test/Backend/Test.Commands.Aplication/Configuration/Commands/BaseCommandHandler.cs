using AutoMapper;
using MediatR;

namespace Test.Commands.Application.Configuration.Commands
{
    public abstract class BaseCommandHandler<T, R> : IRequestHandler<T, R> where T : BaseCommand<R> where R : class
    {
        protected readonly IMapper _mapper;

        public BaseCommandHandler(IMapper mapper)
        {

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public virtual Task<R> Handle(T request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
