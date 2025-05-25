namespace PC.Group.Transactions.Domain.Entities;

public class TransactionPortion : BaseEntity
{
    public decimal Amount { get; set; }

    public bool Settled { get; set; }

    public long TransactionId { get; set; }

    public Transaction Transaction { get; set; } = null!;

    public long DebtorId { get; set; }

    public Member Debtor { get; set; } = null!;
}
