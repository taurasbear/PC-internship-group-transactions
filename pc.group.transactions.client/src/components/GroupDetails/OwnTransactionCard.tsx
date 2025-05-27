import type { TransactionSummary } from "@/shared/types/features/transaction/getTransactionsSummaries/GetTransactionsSummariesResponse";

export interface OwnTransactionCardProps {
  transaction: TransactionSummary;
}

const OwnTransactionCard: React.FC<OwnTransactionCardProps> = ({
  transaction,
}) => {
  return (
    <div className="bg-foreground text-background grid w-full grid-cols-5 rounded-md p-2 shadow">
      <div className="col-span-3">
        <div className="flex flex-row items-end gap-x-1">
          <p className="text-md font-light">To:</p>
          <h2 className="text-lg font-normal">You</h2>
        </div>
        <p className="text-sm font-extralight">
          {transaction.memberCount} members
        </p>
      </div>
      <div className="col-span-2">
        <p className="text-md text-end font-light">
          {transaction.splittingMethod}
        </p>
        <p className="text-end text-2xl font-bold">
          {transaction.totalAmount} €
        </p>
      </div>
    </div>
  );
};

export default OwnTransactionCard;
