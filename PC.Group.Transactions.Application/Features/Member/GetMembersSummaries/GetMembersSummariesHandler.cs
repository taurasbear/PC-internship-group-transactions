namespace PC.Group.Transactions.Application.Features.Member.GetMembersSummaries;

using AutoMapper;
using PC.Group.Transactions.Application.Common.Exception;
using PC.Group.Transactions.Application.Interfaces.Data;
using System.Threading;
using System.Threading.Tasks;

public class GetMembersSummariesHandler : BaseHandler<GetMembersSummariesRequest, GetMembersSummariesResponse>
{
    public GetMembersSummariesHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    { }

    public override async Task<GetMembersSummariesResponse> Handle(GetMembersSummariesRequest request, CancellationToken cancellationToken)
    {
        var group = await this.UnitOfWork.GroupRepository.GetGroupDetailsByGroupIdAsync(request.groupId, cancellationToken);

        if (group == null)
        {
            throw new BadRequestException($"Group with Id: {request.groupId}, does not exist");
        }

        var response = new GetMembersSummariesResponse();

        response.GroupTitle = group.Title;

        foreach (var member in group.Members.Where(member => member.UserId != request.userId))
        {
            var summary = this.Mapper.Map<GetMembersSummariesResponse.MemberSummary>(member);

            var memberOwesUser = member.TransactionPortions
                .Where(portion => portion.Transaction.Payer.UserId == request.userId && !portion.Settled)
                .Sum(portion => portion.Amount);

            var userOwesMember = member.Transactions
                .SelectMany(transaction => transaction.TransactionPortions)
                .Where(portion => portion.Debtor.UserId == request.userId)
                .Sum(portion => portion.Amount);

            var owedAmount = memberOwesUser - userOwesMember;
            summary.OwedAmount = Math.Abs(owedAmount);
            summary.IsUserOwed = owedAmount > 0;

            response.MemberSummaries.Add(summary);
        }

        return response;
    }
}