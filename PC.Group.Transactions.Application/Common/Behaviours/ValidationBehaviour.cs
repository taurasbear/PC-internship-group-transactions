namespace PC.Group.Transactions.Application.Common.Behaviours;

using FluentValidation;
using MediatR;
using PC.Group.Transactions.Application.Common.Exception;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        this.validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!this.validators.Any()) return await next();

        var context = new ValidationContext<TRequest>(request);

        var errors = this.validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .Select(x => x.ErrorMessage)
            .Distinct()
            .ToArray();

        if (errors.Any())
            throw new BadRequestException(errors);

        return await next();
    }
}
