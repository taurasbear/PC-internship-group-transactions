namespace PC.Group.Transactions.Application.Features.Group.GetGroupsSummaries;

using FluentValidation;
using PC.Group.Transactions.Domain.Constants;

public sealed class GetGroupsSummariesValidator : AbstractValidator<GetGroupsSummariesRequest>
{
    public GetGroupsSummariesValidator()
    {
        this.RuleFor(request => request.userId)
            .GreaterThanOrEqualTo(ValidationConstants.MinId);
    }
}