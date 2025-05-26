namespace PC.Group.Transactions.Infrastructure;

using Microsoft.Extensions.DependencyInjection;
using PC.Group.Transactions.Application.Interfaces.Data;
using PC.Group.Transactions.Infrastructure.Data;
using PC.Group.Transactions.Infrastructure.Data.DbContext;

public static class ServiceExtensions
{
    public static void ConfigureInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<TransactionContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
