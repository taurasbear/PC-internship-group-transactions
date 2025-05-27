namespace PC.Group.Transactions.Application.Features.Member.GetMembersSummaries;

public sealed record class GetMembersSummariesResponse
{
    public string GroupTitle { get; set; } = string.Empty;

    public List<MemberSummary> MemberSummaries { get; set; } = new List<MemberSummary>();

    public sealed record class MemberSummary
    {
        public long MemberId { get; set; }

        public string Username { get; set; } = string.Empty;

        public decimal OwedAmount { get; set; }

        public bool IsUserOwed { get; set; }
    }
}