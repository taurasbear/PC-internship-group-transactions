namespace PC.Group.Transactions.Application.Features.Group.GetGroupsSummaries;

using AutoMapper;
using PC.Group.Transactions.Application.Interfaces.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class GetGroupsSummariesHandler : BaseHandler<GetGroupsSummariesRequest, GetGroupsSummariesResponse>
{
    public GetGroupsSummariesHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    { }

    public override async Task<GetGroupsSummariesResponse> Handle(GetGroupsSummariesRequest request, CancellationToken cancellationToken)
    {
        var groupsDetails = await this.UnitOfWork.GroupRepository.GetGroupsDetailsByUserIdAsync(request.userId, cancellationToken);

        var response = new GetGroupsSummariesResponse();
        foreach (var group in groupsDetails)
        {
            var userMember = group.Members
                .FirstOrDefault(member => member.UserId == request.userId)!;

            decimal owedAmount = userMember.Transactions
                                     .Sum(transaction => transaction.Amount) -
                                 userMember.TransactionPortions
                                     .Where(portion => !portion.Settled)
                                     .Sum(portion => portion.Amount);

            var groupSummary = this.Mapper.Map<GetGroupsSummariesResponse.GroupSummary>(group);
            groupSummary.OwedAmount = Math.Abs(owedAmount);
            groupSummary.IsUserOwed = owedAmount > 0;

            response.GroupSummaries.Add(groupSummary);
        }

        return response;
    }
}