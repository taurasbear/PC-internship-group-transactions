import GroupDetailsView from "@/components/GroupDetails/GroupDetailsView";
import QueryBoundary from "@/components/shared/QueryBoundary";
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
      <GroupDetailsView
        transactions={transactions!}
        members={members!}
        nonMembers={nonMembers!}
        onAddMember={handleAddMember}
      />
    </QueryBoundary>
  );
};

export default GroupDetails;
