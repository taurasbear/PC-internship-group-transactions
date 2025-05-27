import MemberCard from "@/components/GroupDetails/MemberCard";
import OwnTransactionCard from "@/components/GroupDetails/OwnTransactionCard";
import TransactionCard from "@/components/GroupDetails/TransactionCard";
import QueryBoundary from "@/components/shared/QueryBoundary";
import { Button } from "@/components/ui/button";
import { Route } from "@/routes/group/$groupId";
import { useGetTransactionsSummaries } from "@/utils/queries/TransactionQueries";

const GroupDetails = () => {
  const { groupId } = Route.useParams();
  const groupIdNumber = Number(groupId);

  const {
    data: transactions,
    error,
    isLoading,
  } = useGetTransactionsSummaries({
    userId: import.meta.env.VITE_USER_ID,
    groupId: groupIdNumber,
  });

  return (
    <QueryBoundary isLoading={isLoading} error={error}>
      <div className="flex flex-col items-center justify-center">
        <h1>{groupId}</h1>
        <div className="flex flex-row gap-x-4">
          <div className="grid w-xs gap-y-10 pt-16 self-start">
            <div className="flex flex-row justify-around">
              <Button className="h-6 w-36">+ New transaction</Button>
              <Button className="h-6 w-30" variant="outline">
                + Add member
              </Button>
            </div>
            <MemberCard />
          </div>
          <div className="flex flex-col">
            <h1 className="w-full text-end">All transactions</h1>
            <div className="grid w-md grid-cols-3 gap-y-4 border-2 p-4">
              {transactions?.transactionSummaries.map((transaction) =>
                transaction.isUserThePayer ? (
                  <div
                    key={transaction.transactionId}
                    className="col-span-2 col-start-1"
                  >
                    <OwnTransactionCard transaction={transaction} />
                  </div>
                ) : (
                  <div
                    key={transaction.transactionId}
                    className="col-span-2 col-start-2"
                  >
                    <TransactionCard transaction={transaction} />
                  </div>
                ),
              )}
            </div>
          </div>
        </div>
      </div>
    </QueryBoundary>
  );
};

export default GroupDetails;
