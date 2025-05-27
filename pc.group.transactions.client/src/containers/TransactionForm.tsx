import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import {
  Select,
  SelectContent,
  SelectGroup,
  SelectItem,
  SelectLabel,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { SplittingMethod } from "@/shared/types/enums/SplittingMethod";
import { useState } from "react";
import { toast } from "sonner";

export interface TransactionFormProps {
  members: [];
  onAdd: (payerId: number) => Promise<void>;
}

const TransactionForm: React.FC<TransactionFormProps> = ({
  members,
  onAdd,
}) => {
  const [payer, setPayer] = useState<number | null>(null);
  const [splittingMethod, setSplittingMethod] = useState<SplittingMethod>(
    SplittingMethod.Equally,
  );

  const handlePayerChange = (payerId: number) => {
    setPayer(payerId);
  };

  const handleMethodChange = (methodId: number) => {};

  const handleSubmit = () => {
    // Validate
    //toast
    onAdd(payer);
  };

  return (
    <div className="w-full items-center justify-center gap-y-10">
      <Select onValueChange={(value) => handlePayerChange(Number(value))}>
        <SelectTrigger>
          <SelectValue placeholder="Select the member who pays" />
        </SelectTrigger>
        <SelectContent>
          <SelectGroup>
            <SelectLabel>Payer</SelectLabel>
            {members.members.map((member) => (
              <SelectItem
                key={member.memberId}
                value={member.memberId.toString()}
              >
                {member.username}
              </SelectItem>
            ))}
          </SelectGroup>
        </SelectContent>
      </Select>
      <div>
        <Label htmlFor="amount">Pay amount</Label>
        <Input id="amount" />
      </div>
      <Select
        onValueChange={(value) => handleMethodChange(Number(value))}
        defaultValue={splittingMethod.valueOf().toString()}
      >
        <SelectTrigger>
          <SelectValue placeholder="Select a splitting method" />
        </SelectTrigger>
        <SelectContent>
          <SelectGroup>
            <SelectLabel>Splitting method</SelectLabel>
            <SelectItem
              key={SplittingMethod.Equally.valueOf()}
              value={SplittingMethod.Equally.valueOf().toString()}
            >
              {SplittingMethod.Equally.toString()}
            </SelectItem>
            <SelectItem
              key={SplittingMethod.Dynamic.valueOf()}
              value={SplittingMethod.Dynamic.valueOf().toString()}
            >
              {SplittingMethod.Dynamic.toString()}
            </SelectItem>
            <SelectItem
              key={SplittingMethod.Percentage.valueOf()}
              value={SplittingMethod.Percentage.valueOf().toString()}
            >
              {SplittingMethod.Percentage.toString()}
            </SelectItem>
          </SelectGroup>
        </SelectContent>
      </Select>
      <Button onClick={handleSubmit}>Submit</Button>
    </div>
  );
};

export default TransactionForm;
