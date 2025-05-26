import { useQuery } from "@tanstack/react-query";
import GroupService from "../services/GroupService";
import type { GetGroupsSummariesRequest } from "@/shared/types/features/getGroupsSummaries/GetGroupsSummariesRequest";

export const useGetGroupsSummaries = (request: GetGroupsSummariesRequest) => {
  return useQuery({
    queryKey: ["summaries", request],
    queryFn: () => GroupService.getGroupsSummaries(request),
  });
};
