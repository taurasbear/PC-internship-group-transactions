namespace PC.Group.Transactions.Application.Features.Member.AddMember;

using FluentValidation;
using PC.Group.Transactions.Domain.Constants;

public sealed class AddMemberValidator : AbstractValidator<AddMemberRequest>
{
    public AddMemberValidator()
    {
        this.RuleFor(request => request.groupId)
            .GreaterThanOrEqualTo(ValidationConstants.MinId);

        this.RuleFor(request => request.userId)
            .GreaterThanOrEqualTo(ValidationConstants.MinId);
    }
}