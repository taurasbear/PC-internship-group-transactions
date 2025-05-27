namespace PC.Group.Transactions.Application.Features.Member.AddMember;

using AutoMapper;
using MediatR;
using PC.Group.Transactions.Application.Interfaces.Data;
using PC.Group.Transactions.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

public class AddMemberHandler : IRequestHandler<AddMemberRequest>
{
    private readonly IMapper mapper;

    private readonly IUnitOfWork unitOfWork;

    public AddMemberHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task Handle(AddMemberRequest request, CancellationToken cancellationToken)
    {
        var memberToAdd = this.mapper.Map<Member>(request);
        await this.unitOfWork.MemberRepository.AddAsync(memberToAdd, cancellationToken);
        await this.unitOfWork.SaveAsync(cancellationToken);
    }
}