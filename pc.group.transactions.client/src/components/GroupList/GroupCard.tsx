import type { GroupSummary } from "@/shared/types/features/getGroupsSummaries/GetGroupsSummariesResponse";

// const imgURL ="https://images.unsplash.com/photo-1747996714434-64de72199155?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D";
const imgURL =
  "https://images.pexels.com/photos/1366919/pexels-photo-1366919.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1";

export interface GroupCardProps {
  group: GroupSummary;
}
const GroupCard: React.FC<GroupCardProps> = ({ group }) => {
  return (
    <div className="w-full flex flex-row shadow text-card-foreground bg-card">
      <div className="flex items-center justify-center p-2 w-32">
        <img
          className=" aspect-square object-cover rounded-full"
          src={imgURL}
        />
      </div>
      <div className="flex flex-col w-full">
        <h2 className="font-normal text-lg">{group.title}</h2>
        <p className="font-extralight text-sm">{group.memberCount} members</p>
        <p className="font-light text-md text-end">{group.isUserOwed ? "Total owed:" : "Total borrowed:"}</p>
        <p className="font-bold text-2xl text-end">{group.owedAmount} €</p>
      </div>
    </div>
  );
};

export default GroupCard;
