import GroupCard from "@/components/GroupList/GroupCard";
import { Button } from "@/components/ui/button";
import {
  Dialog,
  DialogClose,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { useGetGroupsSummaries } from "@/utils/queries/GroupQueries";

const GroupList = () => {
  const {
    data: groups,
    error,
    isLoading,
  } = useGetGroupsSummaries({ userId: 1 });

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
          <Dialog>
            <DialogTrigger asChild>
              <Button variant="outline" className="items-end">
                +Add group
              </Button>
            </DialogTrigger>
            <DialogContent>
              <DialogHeader>
                <DialogTitle>Add group</DialogTitle>
                <DialogDescription>
                  Create a new group for transactions
                </DialogDescription>
              </DialogHeader>
              <div className="grid grid-cols-4 gap-4">
                <Label htmlFor="group-name" className="justify-end">
                  Group name
                </Label>
                <Input id="group-name" className="col-span-3" />
              </div>
              <DialogFooter>
                <DialogClose asChild>
                  <Button variant="secondary">Confirm</Button>
                </DialogClose>
              </DialogFooter>
            </DialogContent>
          </Dialog>
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
