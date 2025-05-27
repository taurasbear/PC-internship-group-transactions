namespace PC.Group.Transactions.Application.Features.Transaction.GetTransactionsSummaries;

using FluentValidation;
using PC.Group.Transactions.Domain.Constants;

public sealed class GetTransactionsSummariesValidator : AbstractValidator<GetTransactionsSummariesRequest>
{
    public GetTransactionsSummariesValidator()
    {
        this.RuleFor(request => request.groupId)
            .GreaterThanOrEqualTo(ValidationConstants.MinId);

        this.RuleFor(request => request.userId)
            .GreaterThanOrEqualTo(ValidationConstants.MinId);
    }
}