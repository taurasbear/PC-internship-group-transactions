namespace PC.Group.Transactions.Application.Features.Transaction.GetTransactionsSummaries;

using AutoMapper;
using PC.Group.Transactions.Application.Common.Exception;
using PC.Group.Transactions.Application.Interfaces.Data;
using System.Threading;
using System.Threading.Tasks;

public class GetTransactionsSummariesHandler : BaseHandler<GetTransactionsSummariesRequest, GetTransactionsSummariesResponse>
{
    public GetTransactionsSummariesHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    { }

    public override async Task<GetTransactionsSummariesResponse> Handle(GetTransactionsSummariesRequest request, CancellationToken cancellationToken)
    {
        var group = await this.UnitOfWork.GroupRepository.GetGroupDetailsByGroupIdAsync(request.groupId, cancellationToken);

        if (group == null)
        {
            throw new BadRequestException($"Group with Id: {request.groupId}, does not exist");
        }

        var response = new GetTransactionsSummariesResponse();

        foreach (var transaction in group.Members.SelectMany(member => member.Transactions))
        {
            var summary = this.Mapper.Map<GetTransactionsSummariesResponse.TransactionSummary>(transaction);
            if (transaction.Payer.UserId == request.userId)
            {
                summary.IsUserThePayer = true;
                summary.OwedAmount = 0;
            }
            else
            {
                summary.IsUserThePayer = false;

                var userPortion = transaction.TransactionPortions
                    .FirstOrDefault(portion => portion.Debtor.UserId == request.userId);

                summary.OwedAmount = userPortion == null ? 0 : userPortion.Amount;
            }

            response.TransactionSummaries.Add(summary);
        }

        return response;
    }
}