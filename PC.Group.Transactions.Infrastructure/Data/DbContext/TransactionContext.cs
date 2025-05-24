namespace PC.Group.Transactions.Infrastructure.Data.DbContext;

using Microsoft.EntityFrameworkCore;
using PC.Group.Transactions.Domain.Entities;

public class TransactionContext : DbContext
{
    public TransactionContext(DbContextOptions options) : base(options)
    { }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("GroupTransactionsDb");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();
    }
}

