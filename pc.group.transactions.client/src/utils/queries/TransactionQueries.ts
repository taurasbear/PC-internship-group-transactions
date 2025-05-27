import type { GetTransactionsSummariesRequest } from "@/shared/types/features/transaction/getTransactionsSummaries/GetTransactionsSummariesRequest";
import { useQuery } from "@tanstack/react-query";
import TransactionService from "../services/TransactionService";

export const useGetTransactionsSummaries = (
  request: GetTransactionsSummariesRequest,
) => {
  return useQuery({
    queryKey: ["transaction-summaries", request],
    queryFn: () => TransactionService.GetTransactionsSummaries(request),
  });
};
