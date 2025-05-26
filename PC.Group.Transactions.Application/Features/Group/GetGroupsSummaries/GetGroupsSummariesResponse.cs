namespace PC.Group.Transactions.Application.Features.Group.GetGroupsSummaries;

public sealed record class GetGroupsSummariesResponse
{
    public List<GroupSummary> GroupSummaries { get; set; } = new List<GroupSummary>();

    public sealed record class GroupSummary
    {
        public long GroupId { get; set; }

        public string Title { get; set; } = string.Empty;

        public int MemberCount { get; set; }

        public decimal OwedAmount { get; set; }

        public bool IsUserOwed { get; set; }
    }
}