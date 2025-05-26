import GroupList from "@/containers/GroupList";
import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/")({
  component: GroupList,
});
