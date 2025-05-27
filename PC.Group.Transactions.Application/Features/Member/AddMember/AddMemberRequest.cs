namespace PC.Group.Transactions.Application.Features.Member.AddMember;

using MediatR;

public sealed record class AddMemberRequest(long groupId, long userId) : IRequest;
