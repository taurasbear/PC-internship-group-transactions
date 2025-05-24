namespace PC.Group.Transactions.Infrastructure.Data.DbContext;

using Microsoft.EntityFrameworkCore;
using PC.Group.Transactions.Domain.Entities;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData
        (
            new User { Id = 1, Username = "Bearman"}
        );
    }
}
