namespace PC.Group.Transactions.Application.Features.User.GetNonMemberUsers;

using MediatR;

public sealed record class GetNonMemberUsersRequest(long groupId) : IRequest<GetNonMemberUsersResponse>;
