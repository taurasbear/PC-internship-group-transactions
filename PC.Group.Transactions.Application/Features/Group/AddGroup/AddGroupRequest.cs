namespace PC.Group.Transactions.Application.Features.Group.AddGroup;

using MediatR;

public sealed record class AddGroupRequest(long userId, string title) : IRequest;
