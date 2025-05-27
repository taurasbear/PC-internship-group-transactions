namespace PC.Group.Transactions.Application.Features.User.GetNonMemberUsers;

public sealed record class GetNonMemberUsersResponse
{
    public List<NonMember> NonMembers { get; set; } = new List<NonMember>();

    public sealed record class NonMember
    {
        public long UserId { get; set; }

        public string Username { get; set; } = string.Empty;
    }
}