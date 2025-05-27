export interface GetTransactionsSummariesResponse {
  transactionSummaries: [TransactionSummary];
}

export interface TransactionSummary {
  transactionId: number;
  payer: string;
  memberCount: number;
  splittingMethod: string;
  totalAmount: number;
  isUserThePayer: boolean;
  owedAmount: number;
}
