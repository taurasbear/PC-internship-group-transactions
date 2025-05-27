import AddMemberDialog from "@/components/GroupDetails/AddMemberDialog";
import MemberCard from "@/components/GroupDetails/MemberCard";
import OwnTransactionCard from "@/components/GroupDetails/OwnTransactionCard";
import TransactionCard from "@/components/GroupDetails/TransactionCard";
import QueryBoundary from "@/components/shared/QueryBoundary";
import { Button } from "@/components/ui/button";
import { Route } from "@/routes/group/$groupId";
import {
  useAddMember,
  useGetMembersSummaries,
} from "@/utils/queries/MemberQueries";
import { useGetTransactionsSummaries } from "@/utils/queries/TransactionQueries";
import { useGetNonMemberUsers } from "@/utils/queries/UserQueries";
import { useQueryClient } from "@tanstack/react-query";
import { toast } from "sonner";

const GroupDetails = () => {
  const { groupId } = Route.useParams();
  const groupIdNumber = Number(groupId);

  const queryClient = useQueryClient();
  const addMember = useAddMember();

  const {
    data: transactions,
    error: groupsError,
    isLoading: groupsIsLoading,
  } = useGetTransactionsSummaries({
    userId: import.meta.env.VITE_USER_ID,
    groupId: groupIdNumber,
  });

  const {
    data: members,
    error: membersError,
    isLoading: membersIsLoading,
  } = useGetMembersSummaries({
    userId: import.meta.env.VITE_USER_ID,
    groupId: groupIdNumber,
  });

  const {
    data: nonMembers,
    error: nonMembersError,
    isLoading: nonMembersIsLoading,
  } = useGetNonMemberUsers({
    groupId: groupIdNumber,
  });

  const handleAddMember = async (userId: number) => {
    await addMember
      .mutateAsync({ groupId: groupIdNumber, userId: userId })
      .then(() => {
        toast("Successfully added a member");
        queryClient.invalidateQueries({
          queryKey: [
            "member-summaries",
            {
              userId: import.meta.env.VITE_USER_ID,
              groupId: groupIdNumber,
            },
          ],
        });
        queryClient.invalidateQueries({
          queryKey: [
            "non-members",
            {
              groupId: groupIdNumber,
            },
          ],
        });
      })
      .catch((error) =>
        toast(`Something went wrong while adding a member: ${error.message}`),
      );
  };

  return (
    <QueryBoundary
      isLoading={groupsIsLoading || membersIsLoading || nonMembersIsLoading}
      error={groupsError || membersError || nonMembersError}
    >
      <div className="flex flex-col items-center justify-center">
        <h1 className="text-3xl font-extralight">{members?.groupTitle}</h1>
        <div className="flex flex-row gap-x-4">
          <div className="grid w-xs gap-y-10 self-start pt-16">
            <div className="flex flex-row justify-around">
              <Button className="h-6 w-36">+ New transaction</Button>
              <AddMemberDialog
                onAdd={handleAddMember}
                nonMembers={nonMembers!}
              />
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
    </QueryBoundary>
  );
};

export default GroupDetails;
