import type { GetMembersSummariesRequest } from "@/shared/types/features/member/getMembersSummaries/GetMembersSummariesRequest";
import { useMutation, useQuery } from "@tanstack/react-query";
import MemberService from "../services/MemberService";
import type { AddMemberRequest } from "@/shared/types/features/member/addMember/AddMemberRequest";

export const useGetMembersSummaries = (request: GetMembersSummariesRequest) => {
  return useQuery({
    queryKey: ["member-summaries", request],
    queryFn: () => MemberService.GetMembersSummaries(request),
  });
};

export const useAddMember = () => {
  return useMutation({
    mutationKey: ["member-add"],
    mutationFn: (request: AddMemberRequest) => MemberService.AddMember(request),
  });
};
