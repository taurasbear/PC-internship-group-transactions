import type { GetMembersSummariesRequest } from "@/shared/types/features/member/getMembersSummaries/GetMembersSummariesRequest";
import { useQuery } from "@tanstack/react-query";
import MemberService from "../services/MemberService";

export const useGetMembersSummaries = (request: GetMembersSummariesRequest) => {
  return useQuery({
    queryKey: ["member-summaries", request],
    queryFn: () => MemberService.GetMembersSummaries(request),
  });
};
