import axiosClient from "@/api/axiosClient";
import type { GetTransactionsSummariesRequest } from "@/shared/types/features/transaction/getTransactionsSummaries/GetTransactionsSummariesRequest";
import type { GetTransactionsSummariesResponse } from "@/shared/types/features/transaction/getTransactionsSummaries/GetTransactionsSummariesResponse";

class TransactionService {
  static async GetTransactionsSummaries(
    request: GetTransactionsSummariesRequest,
  ): Promise<GetTransactionsSummariesResponse> {
    const params = new URLSearchParams({
      userId: request.userId.toString(),
      groupId: request.groupId.toString(),
    });

    const response = await axiosClient.get("/transaction/summaries", {
      params,
    });

    return response.data;
  }
}

export default TransactionService;
