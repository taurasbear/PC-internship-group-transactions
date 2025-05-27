namespace PC.Group.Transactions.Application.Features.User.GetNonMemberUsers;

using FluentValidation;
using PC.Group.Transactions.Domain.Constants;

public sealed class GetNonMemberUsersValidator : AbstractValidator<GetNonMemberUsersRequest>
{
    public GetNonMemberUsersValidator()
    {
        this.RuleFor(request => request.groupId)
            .GreaterThanOrEqualTo(ValidationConstants.MinId);
    }
}