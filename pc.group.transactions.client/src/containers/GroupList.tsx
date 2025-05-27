import GroupListView from "@/components/GroupList/GroupListView";
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
    console.log("GOT IT!")
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
      <GroupListView onAdd={handleAdd} groups={groups!} />
    </QueryBoundary>
  );
};

export default GroupList;
