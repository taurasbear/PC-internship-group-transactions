import axiosClient from "@/api/axiosClient";
import type { GetNonMemberUsersRequest } from "@/shared/types/features/user/getNonMemberUsers/getNonMemberUsersRequest";
import type { GetNonMemberUsersResponse } from "@/shared/types/features/user/getNonMemberUsers/getNonMemberUsersResponse";

class UserService {
  static async GetNonMemberUsers(
    request: GetNonMemberUsersRequest,
  ): Promise<GetNonMemberUsersResponse> {
    const params = new URLSearchParams({ groupId: request.groupId.toString() });
    const response = await axiosClient.get("/user/non-members", { params });
    return response.data;
  }
}

export default UserService;
