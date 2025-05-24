namespace PC.Group.Transactions.Application;

using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PC.Group.Transactions.Application.Common.Behaviours;
using System.Reflection;

public static class ServiceExtensions
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
