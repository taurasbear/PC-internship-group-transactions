namespace PC.Group.Transactions.Application.Features.Transaction.GetTransactionsSummaries;

public sealed record class GetTransactionsSummariesResponse
{
    public List<TransactionSummary> TransactionSummaries { get; set; } = new List<TransactionSummary>();

    public sealed record class TransactionSummary
    {
        public long TransactionId { get; set; }

        public string Payer { get; set; } = string.Empty;

        public int MemberCount { get; set; }

        public string SplittingMethod { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public bool IsUserThePayer { get; set; }

        public decimal OwedAmount { get; set; }
    }
}