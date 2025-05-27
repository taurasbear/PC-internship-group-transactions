namespace PC.Group.Transactions.Application.Features.Transaction.GetTransactionsSummaries;

using MediatR;

public sealed record class GetTransactionsSummariesRequest(long userId, long groupId) : IRequest<GetTransactionsSummariesResponse>;
