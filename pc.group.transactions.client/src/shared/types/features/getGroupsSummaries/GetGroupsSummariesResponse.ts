export interface GetGroupsSummariesResponse {
  groupSummaries: [GroupSummary];
}

export interface GroupSummary {
  groupId: number;
  title: string;
  memberCount: number;
  owedAmount: number;
  isUserOwed: boolean;
}
