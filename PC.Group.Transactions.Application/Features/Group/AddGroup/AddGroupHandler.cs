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
        var groupToAdd = this.mapper.Map<Group>(request);
        var memberToAdd = this.mapper.Map<Member>(request);
        groupToAdd.Members.Add(memberToAdd);

        await this.unitOfWork.GroupRepository.AddAsync(groupToAdd, cancellationToken);
        await this.unitOfWork.SaveAsync(cancellationToken);
    }
}