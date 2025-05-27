import type { GroupSummary } from "@/shared/types/features/group/getGroupsSummaries/GetGroupsSummariesResponse";
import { Link } from "@tanstack/react-router";

// const imgURL ="https://images.unsplash.com/photo-1747996714434-64de72199155?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D";
const imgURL =
  "https://images.pexels.com/photos/1366919/pexels-photo-1366919.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1";

export interface GroupCardProps {
  group: GroupSummary;
}
const GroupCard: React.FC<GroupCardProps> = ({ group }) => {
  return (
    <Link
      to={`/group/${group.groupId}`}
      className="text-card-foreground bg-card hover:bg-muted flex w-full flex-row no-underline shadow transition-colors"
      aria-label={`View details for group ${group.title}`}
    >
      <div className="flex w-32 items-center justify-center p-2">
        <img
          className="aspect-square rounded-full object-cover"
          src={imgURL}
          alt={`${group.title} group`}
        />
      </div>
      <div className="flex w-full flex-col">
        <h2 className="text-lg font-normal">{group.title}</h2>
        <p className="text-sm font-extralight">{group.memberCount} members</p>
        <p className="text-md text-end font-light">
          {group.isUserOwed ? "Total owed:" : "Total borrowed:"}
        </p>
        <p className="text-end text-2xl font-bold">{group.owedAmount} €</p>
      </div>
    </Link>
  );
};

export default GroupCard;
