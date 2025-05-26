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
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { z } from "zod";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "../ui/form";

export interface AddGroupDialogProps {
  onAdd: (title: string) => Promise<void>;
}

const formSchema = z.object({
  title: z
    .string()
    .min(import.meta.env.VITE_MIN_GROUP_TITLE_LENGTH, {
      message: "Group title is required",
    })
    .max(import.meta.env.VITE_MAX_GROUP_TITLE_LENGTH, {
      message: "Group title should be less than 30 characters",
    }),
});

const AddGroupDialog: React.FC<AddGroupDialogProps> = ({ onAdd }) => {
  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: { title: "" },
  });

  const onSubmit = async (values: z.infer<typeof formSchema>) => {
    await onAdd(values.title);
    form.reset();
  };

  const handleOpen = (open: boolean) => {
    if (!open) {
      form.reset();
    }
  };

  return (
    <Dialog onOpenChange={(open) => handleOpen(open)}>
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
        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-6">
            <FormField
              control={form.control}
              name="title"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Group title</FormLabel>
                  <FormControl>
                    <Input placeholder="Group name" {...field} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <DialogFooter>
              <DialogClose asChild>
                <Button
                  variant="secondary"
                  type="submit"
                  disabled={
                    !form.formState.isValid || form.formState.isSubmitting
                  }
                >
                  Confirm
                </Button>
              </DialogClose>
            </DialogFooter>
          </form>
        </Form>
      </DialogContent>
    </Dialog>
  );
};

export default AddGroupDialog;
