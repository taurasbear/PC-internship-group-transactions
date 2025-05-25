namespace PC.Group.Transactions.Domain.Entities;

public class Group : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public ICollection<Member> Members { get; set; } = new List<Member>();
}
