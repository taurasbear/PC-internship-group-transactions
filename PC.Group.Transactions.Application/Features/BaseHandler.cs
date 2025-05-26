namespace PC.Group.Transactions.Application.Features;

using AutoMapper;
using MediatR;
using PC.Group.Transactions.Application.Interfaces.Data;
using System.Threading;
using System.Threading.Tasks;

public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    protected IMapper Mapper { get; set; }

    protected IUnitOfWork UnitOfWork { get; set; }

    protected BaseHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.Mapper = mapper;
        this.UnitOfWork = unitOfWork;
    }

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}
