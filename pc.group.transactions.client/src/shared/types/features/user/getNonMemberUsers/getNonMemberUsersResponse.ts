export interface GetNonMemberUsersResponse {
  nonMembers: [NonMember];
}

export interface NonMember {
  userId: number;
  username: string;
}
