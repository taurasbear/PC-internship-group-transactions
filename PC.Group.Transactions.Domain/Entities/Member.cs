namespace PC.Group.Transactions.Domain.Entities;

public class Member : BaseEntity
{
    public bool Removed { get; set; }

    public long UserId { get; set; }

    public User User { get; set; } = null!;

    public long GroupId { get; set; }

    public Group Group { get; set; } = null!;

    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public ICollection<TransactionPortion> TransactionPortions { get; set; } = new List<TransactionPortion>();
}
