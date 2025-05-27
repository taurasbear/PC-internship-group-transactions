import axiosClient from "@/api/axiosClient";
import type { AddGroupRequest } from "@/shared/types/features/group/addGroup/AddGroupRequest";
import type { GetGroupsSummariesRequest } from "@/shared/types/features/group/getGroupsSummaries/GetGroupsSummariesRequest";
import type { GetGroupsSummariesResponse } from "@/shared/types/features/group/getGroupsSummaries/GetGroupsSummariesResponse";

class GroupService {
  static async getGroupsSummaries(
    request: GetGroupsSummariesRequest
  ): Promise<GetGroupsSummariesResponse> {
    const params = new URLSearchParams({ userId: request.userId.toString() });
    const response = await axiosClient.get("/group/summaries", { params });
    return response.data;
  }

  static async addGroup(request: AddGroupRequest): Promise<void> {
    await axiosClient.post("/group", request);
  }
}

export default GroupService;
