namespace PC.Group.Transactions.Application.Features.Member.GetMembersSummaries;

using MediatR;

public sealed record class GetMembersSummariesRequest(long userId, long groupId) : IRequest<GetMembersSummariesResponse>;
