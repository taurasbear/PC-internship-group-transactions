import TransactionForm from "@/containers/TransactionForm";
import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/group/$groupId/transactions/new")({
  component: TransactionForm,
});
