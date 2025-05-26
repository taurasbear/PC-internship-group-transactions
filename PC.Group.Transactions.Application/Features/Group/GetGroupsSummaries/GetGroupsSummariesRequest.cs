namespace PC.Group.Transactions.Application.Features.Group.GetGroupsSummaries;

using MediatR;

public sealed record class GetGroupsSummariesRequest(long userId) : IRequest<GetGroupsSummariesResponse>;
