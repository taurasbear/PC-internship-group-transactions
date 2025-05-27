import axiosClient from "@/api/axiosClient";
import type { GetMembersSummariesRequest } from "@/shared/types/features/member/getMembersSummaries/GetMembersSummariesRequest";
import type GetMembersSummariesResponse from "@/shared/types/features/member/getMembersSummaries/GetMembersSummariesResponse";

class MemberService {
  static async GetMembersSummaries(
    request: GetMembersSummariesRequest,
  ): Promise<GetMembersSummariesResponse> {
    const params = new URLSearchParams({
      userId: request.userId.toString(),
      groupId: request.groupId.toString(),
    });

    const response = await axiosClient.get("/member/summaries", { params });
    return response.data;
  }
}

export default MemberService;
