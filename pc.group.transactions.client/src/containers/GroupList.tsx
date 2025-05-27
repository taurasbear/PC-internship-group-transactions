import AddGroupDialog from "@/components/GroupList/AddGroupDialog";
import GroupCard from "@/components/GroupList/GroupCard";
import QueryBoundary from "@/components/shared/QueryBoundary";
import {
  useAddGroup,
  useGetGroupsSummaries,
} from "@/utils/queries/GroupQueries";
import { useQueryClient } from "@tanstack/react-query";
import { toast } from "sonner";

const GroupList = () => {
  const userId = import.meta.env.VITE_USER_ID;
  const queryClient = useQueryClient();
  const {
    data: groups,
    error,
    isLoading,
  } = useGetGroupsSummaries({ userId: userId });
  const addGroup = useAddGroup();
  const handleAdd = async (title: string) => {
    await addGroup
      .mutateAsync({ userId: userId, title: title })
      .then(() => {
        toast("Successfully added a group");
        queryClient.invalidateQueries({
          queryKey: ["group-summaries", { userId: userId }],
        });
      })
      .catch((error) =>
        toast(`Something went wrong while adding a group: ${error.message}`),
      );
  };

  return (
    <QueryBoundary isLoading={isLoading} error={error}>
      <div className="flex w-full flex-col items-center">
        <h1 className="text-3xl font-extralight">Groups</h1>
        <div className="w-xs pt-16">
          <div className="flex justify-end pr-2 pb-2">
            <AddGroupDialog onAdd={handleAdd} />
          </div>
          <div className="grid gap-y-10">
            {groups?.groupSummaries.map((summary) => (
              <GroupCard key={summary.groupId} group={summary} />
            ))}
          </div>
        </div>
      </div>
    </QueryBoundary>
  );
};

export default GroupList;
