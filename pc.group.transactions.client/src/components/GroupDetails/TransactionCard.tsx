import type { TransactionSummary } from "@/shared/types/features/transaction/getTransactionsSummaries/GetTransactionsSummariesResponse";

export interface TransactionCardProps {
  transaction: TransactionSummary;
}

const TransactionCard: React.FC<TransactionCardProps> = ({ transaction }) => {
  return (
    <div className="bg-card grid w-full grid-cols-5 rounded-md p-2 shadow">
      <div className="col-span-3">
        <div className="flex flex-row items-end gap-x-1">
          <p className="text-md font-light">To:</p>
          <h2 className="text-lg font-normal">{transaction.payer}</h2>
        </div>
        <p className="text-sm font-extralight">
          {transaction.memberCount} members
        </p>
      </div>
      <div className="col-span-2">
        <p className="text-md text-end font-light">
          {transaction.splittingMethod}
        </p>
        <p className="text-end text-sm font-normal">
          {transaction.totalAmount} €
        </p>
        <p className="text-md text-end font-light">Your part:</p>
        <p className="text-end text-2xl font-bold">
          {transaction.owedAmount} €
        </p>
      </div>
    </div>
  );
};

export default TransactionCard;
