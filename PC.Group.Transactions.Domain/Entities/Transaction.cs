namespace PC.Group.Transactions.Domain.Entities;

using PC.Group.Transactions.Domain.Enums;

public class Transaction : BaseEntity
{
    public decimal Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public SplittingMethod Method { get; set; }

    public long PayerId { get; set; }

    public Member Payer { get; set; } = null!;

    public ICollection<TransactionPortion> TransactionPortions { get; set; } = new List<TransactionPortion>();
}
