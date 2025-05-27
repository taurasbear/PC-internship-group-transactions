import {
  Dialog,
  DialogClose,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "../ui/dialog";
import { Button } from "../ui/button";
import {
  Select,
  SelectContent,
  SelectGroup,
  SelectItem,
  SelectLabel,
  SelectTrigger,
  SelectValue,
} from "../ui/select";

import { useState } from "react";
import type { GetNonMemberUsersResponse } from "@/shared/types/features/user/getNonMemberUsers/getNonMemberUsersResponse";

export interface AddMemberDialogProps {
  onAdd: (userId: number) => Promise<void>;
  nonMembers: GetNonMemberUsersResponse;
}

const AddMemberDialog: React.FC<AddMemberDialogProps> = ({
  onAdd,
  nonMembers,
}) => {
  const [user, setUser] = useState<number | null>(null);
  const handleChange = (userId: number) => {
    setUser(userId);
  };
  const handleSubmit = () => {
    onAdd(user!);
  };

  const handleOpen = (open: boolean) => {
    if (!open) {
      setUser(null);
    }
  };

  return (
    <Dialog onOpenChange={handleOpen}>
      <DialogTrigger asChild>
        <Button variant="outline" className="h-6 w-30">
          + Add member
        </Button>
      </DialogTrigger>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>Add member</DialogTitle>
          <DialogDescription>Add a user to the group</DialogDescription>
        </DialogHeader>
        <Select onValueChange={(value) => handleChange(Number(value))}>
          <SelectTrigger>
            <SelectValue placeholder="Select a user" />
          </SelectTrigger>
          <SelectContent>
            <SelectGroup>
              <SelectLabel>Users</SelectLabel>
              {nonMembers.nonMembers.map((nonMember) => (
                <SelectItem
                  key={nonMember.userId}
                  value={nonMember.userId.toString()}
                >
                  {nonMember.username}
                </SelectItem>
              ))}
            </SelectGroup>
          </SelectContent>
        </Select>
        <DialogFooter>
          <DialogClose asChild>
            <Button
              variant="secondary"
              type="submit"
              disabled={!user}
              onClick={handleSubmit}
            >
              Confirm
            </Button>
          </DialogClose>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
};

export default AddMemberDialog;
