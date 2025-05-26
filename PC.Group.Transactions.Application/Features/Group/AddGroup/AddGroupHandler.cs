namespace PC.Group.Transactions.Application.Features.Group.AddGroup;

using AutoMapper;
using MediatR;
using PC.Group.Transactions.Application.Interfaces.Data;
using PC.Group.Transactions.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

public class AddGroupHandler : IRequestHandler<AddGroupRequest>
{
    private readonly IUnitOfWork unitOfWork;

    private readonly IMapper mapper;

    public AddGroupHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task Handle(AddGroupRequest request, CancellationToken cancellationToken)
    {
        var group = this.mapper.Map<Group>(request);
        var member = this.mapper.Map<Member>(request);
        group.Members.Add(member);

        await this.unitOfWork.GroupRepository.AddAsync(group, cancellationToken);
        await this.unitOfWork.SaveAsync(cancellationToken);
    }
}