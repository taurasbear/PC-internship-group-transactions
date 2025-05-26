import AddGroupDialog from "@/components/GroupList/AddGroupDialog";
import GroupCard from "@/components/GroupList/GroupCard";
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
          queryKey: ["summaries", { userId: userId }],
        });
      })
      .catch((error) =>
        toast(`Something went wrong while adding a group: ${error.message}`)
      );
  };

  if (isLoading) {
    return <h1>Is loading</h1>;
  }

  if (error) {
    return <h1>{error.message}</h1>;
  }
  return (
    <div className="flex flex-col items-center w-full">
      <h1 className="font-extralight text-3xl">Groups</h1>
      <div className="w-xs pt-16">
        <div className="flex justify-end pb-2 pr-2">
          <AddGroupDialog onAdd={handleAdd} />
        </div>
        <div className="grid gap-y-10">
          {groups?.groupSummaries.map((summary) => (
            <GroupCard key={summary.groupId} group={summary} />
          ))}
        </div>
      </div>
    </div>
  );
};

export default GroupList;
