import GroupDetails from "@/containers/GroupDetails";
import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/group/$groupId")({
  component: GroupDetails,
});
