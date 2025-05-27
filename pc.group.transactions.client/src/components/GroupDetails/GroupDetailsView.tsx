import type GetMembersSummariesResponse from "@/shared/types/features/member/getMembersSummaries/GetMembersSummariesResponse";
import { Button } from "../ui/button";
import AddMemberDialog from "./AddMemberDialog";
import MemberCard from "./MemberCard";
import OwnTransactionCard from "./OwnTransactionCard";
import TransactionCard from "./TransactionCard";
import type { GetNonMemberUsersResponse } from "@/shared/types/features/user/getNonMemberUsers/getNonMemberUsersResponse";
import type { GetTransactionsSummariesResponse } from "@/shared/types/features/transaction/getTransactionsSummaries/GetTransactionsSummariesResponse";

export interface GroupDetailsViewProps {
  members: GetMembersSummariesResponse;
  onAddMember: (userId: number) => Promise<void>;
  nonMembers: GetNonMemberUsersResponse;
  transactions: GetTransactionsSummariesResponse;
}

const GroupDetailsView: React.FC<GroupDetailsViewProps> = ({
  members,
  onAddMember,
  nonMembers,
  transactions,
}) => {
  return (
    <div className="flex flex-col items-center justify-center">
      <h1 className="text-3xl font-extralight">{members?.groupTitle}</h1>
      <div className="flex flex-row gap-x-4">
        <div className="grid w-xs gap-y-10 self-start pt-16">
          <div className="flex flex-row justify-around">
            <Button className="h-6 w-36">+ New transaction</Button>
            <AddMemberDialog onAdd={onAddMember} nonMembers={nonMembers} />
          </div>
          {members?.memberSummaries.map((member) => (
            <MemberCard key={member.memberId} member={member} />
          ))}
        </div>
        <div className="flex flex-col">
          <h1 className="w-full text-end">All transactions</h1>
          <div className="grid w-md grid-cols-3 gap-y-4 border-2 p-4">
            {transactions?.transactionSummaries.map((transaction) =>
              transaction.isUserThePayer ? (
                <div
                  key={transaction.transactionId}
                  className="col-span-2 col-start-1"
                >
                  <OwnTransactionCard transaction={transaction} />
                </div>
              ) : (
                <div
                  key={transaction.transactionId}
                  className="col-span-2 col-start-2"
                >
                  <TransactionCard transaction={transaction} />
                </div>
              ),
            )}
          </div>
        </div>
      </div>
    </div>
  );
};

export default GroupDetailsView;
