namespace PC.Group.Transactions.Application.Features.User.GetNonMemberUsers;

using AutoMapper;
using PC.Group.Transactions.Application.Interfaces.Data;
using System.Threading;
using System.Threading.Tasks;

public class GetNonMemberUsersHandler : BaseHandler<GetNonMemberUsersRequest, GetNonMemberUsersResponse>
{
    public GetNonMemberUsersHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    { }

    public override async Task<GetNonMemberUsersResponse> Handle(GetNonMemberUsersRequest request, CancellationToken cancellationToken)
    {
        var nonMembers = await this.UnitOfWork.UserRepository.GetNonMemberUsersByGroupIdAsync(request.groupId, cancellationToken);
        return this.Mapper.Map<GetNonMemberUsersResponse>(nonMembers);
    }
}