import type { GetGroupsSummariesResponse } from "@/shared/types/features/group/getGroupsSummaries/GetGroupsSummariesResponse";
import AddGroupDialog from "./AddGroupDialog";
import GroupCard from "./GroupCard";

export interface GroupListViewProps {
  onAdd: (title: string) => Promise<void>;
  groups: GetGroupsSummariesResponse;
}

const GroupListView: React.FC<GroupListViewProps> = ({ onAdd, groups }) => {
  return (
    <div className="flex w-full flex-col items-center">
      <h1 className="text-3xl font-extralight">Groups</h1>
      <div className="w-xs pt-16">
        <div className="flex justify-end pr-2 pb-2">
          <AddGroupDialog onAdd={onAdd} />
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

export default GroupListView;
