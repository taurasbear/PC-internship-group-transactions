import axiosClient from "@/api/axiosClient";
import type { AddMemberRequest } from "@/shared/types/features/member/addMember/AddMemberRequest";
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

  static async AddMember(request: AddMemberRequest): Promise<void> {
    await axiosClient.post("/member", request);
  }
}

export default MemberService;
