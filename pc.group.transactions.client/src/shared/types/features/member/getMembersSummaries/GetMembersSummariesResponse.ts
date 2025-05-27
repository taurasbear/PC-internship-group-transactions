export default interface GetMembersSummariesResponse {
  groupTitle: string;
  memberSummaries: [MemberSummary];
}

export interface MemberSummary {
  memberId: number;
  username: string;
  owedAmount: number;
  isUserOwed: boolean;
}
