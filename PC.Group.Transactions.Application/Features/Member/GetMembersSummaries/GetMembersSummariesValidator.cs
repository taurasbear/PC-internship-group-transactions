namespace PC.Group.Transactions.Application.Features.Member.GetMembersSummaries;

using FluentValidation;
using PC.Group.Transactions.Domain.Constants;

public sealed class GetMembersSummariesValidator : AbstractValidator<GetMembersSummariesRequest>
{
    public GetMembersSummariesValidator()
    {
        this.RuleFor(request => request.userId)
            .GreaterThanOrEqualTo(ValidationConstants.MinId);

        this.RuleFor(request => request.groupId)
            .GreaterThanOrEqualTo(ValidationConstants.MinId);
    }
}