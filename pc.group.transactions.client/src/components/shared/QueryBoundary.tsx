import { Spinner } from "../ui/spinner";

interface QueryBoundaryProps {
  isLoading: boolean;
  error: unknown;
  children: React.ReactNode;
}

const QueryBoundary: React.FC<QueryBoundaryProps> = ({
  isLoading,
  error,
  children,
}) => {
  if (isLoading) {
    return (
      <div className="flex min-h-screen w-full items-center justify-center py-8">
        <Spinner />
      </div>
    );
  }

  if (error) {
    return (
      <div className="just min-h-screen w-full text-center text-red-500">
        <p>Something went wrong: {error.message ?? ":("}</p>
      </div>
    );
  }

  return <>{children}</>;
};

export default QueryBoundary;
