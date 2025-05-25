namespace PC.Group.Transactions.Infrastructure.Data.DbContext;

using Microsoft.EntityFrameworkCore;
using PC.Group.Transactions.Domain.Entities;

public class TransactionContext : DbContext
{
    public TransactionContext(DbContextOptions options) : base(options)
    { }

    public DbSet<User> Users { get; set; }

    public DbSet<Group> Groups { get; set; }

    public DbSet<Member> Members { get; set; }

    public DbSet<Transaction> Transactions { get; set; }

    public DbSet<TransactionPortion> TransactionPortions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("GroupTransactionsDb");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Member>()
            .HasOne(member => member.User)
            .WithMany(user => user.Members)
            .HasForeignKey(member => member.UserId);

        modelBuilder.Entity<Member>()
            .HasOne(member => member.Group)
            .WithMany(group => group.Members)
            .HasForeignKey(member => member.GroupId);

        modelBuilder.Entity<Transaction>()
            .HasOne(transaction => transaction.Payer)
            .WithMany(payer => payer.Transactions)
            .HasForeignKey(transaction => transaction.PayerId);

        modelBuilder.Entity<TransactionPortion>()
            .HasOne(transactionPortion => transactionPortion.Transaction)
            .WithMany(transaction => transaction.TransactionPortions)
            .HasForeignKey(transactionPortion => transactionPortion.TransactionId);

        modelBuilder.Entity<TransactionPortion>()
            .HasOne(transactionPortion => transactionPortion.Debtor)
            .WithMany(debtor => debtor.TransactionPortions)
            .HasForeignKey(transactionPortion => transactionPortion.DebtorId);

        modelBuilder.Seed();
    }
}

