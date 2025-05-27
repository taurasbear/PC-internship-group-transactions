import type { GetNonMemberUsersRequest } from "@/shared/types/features/user/getNonMemberUsers/getNonMemberUsersRequest";
import { useQuery } from "@tanstack/react-query";
import UserService from "../services/UserService";

export const useGetNonMemberUsers = (request: GetNonMemberUsersRequest) => {
  return useQuery({
    queryKey: ["non-members", request],
    queryFn: () => UserService.GetNonMemberUsers(request),
  });
};
