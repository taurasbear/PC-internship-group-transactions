import { useMutation, useQuery } from "@tanstack/react-query";
import GroupService from "../services/GroupService";
import type { GetGroupsSummariesRequest } from "@/shared/types/features/getGroupsSummaries/GetGroupsSummariesRequest";
import type { AddGroupRequest } from "@/shared/types/features/addGroup/AddGroupRequest";

export const useGetGroupsSummaries = (request: GetGroupsSummariesRequest) => {
  return useQuery({
    queryKey: ["summaries", request],
    queryFn: () => GroupService.getGroupsSummaries(request),
  });
};

export const useAddGroup = () => {
  return useMutation({
    mutationKey: ["group-add"],
    mutationFn: (request: AddGroupRequest) => GroupService.addGroup(request),
  });
};
