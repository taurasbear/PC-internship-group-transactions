namespace PC.Group.Transactions.Application.Features.Group.GetGroupsSummaries;

using FluentValidation;

public sealed class GetGroupsSummariesValidator : AbstractValidator<GetGroupsSummariesRequest>
{
    public GetGroupsSummariesValidator()
    {
        this.RuleFor(request => request.userId)
            .GreaterThan(0);
    }
}