namespace PC.Group.Transactions.Application.Features.Group.AddGroup;

using FluentValidation;
using PC.Group.Transactions.Domain.Constants;

public sealed class AddGroupValidator : AbstractValidator<AddGroupRequest>
{
    public AddGroupValidator()
    {
        this.RuleFor(request => request.userId)
            .GreaterThan(ValidationConstants.MinId);

        this.RuleFor(request => request.title)
            .NotEmpty()
            .MinimumLength(ValidationConstants.MinGroupTitleLength)
            .MaximumLength(ValidationConstants.MaxGroupTitleLength);
    }
}