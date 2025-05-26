// const imgURL ="https://images.unsplash.com/photo-1747996714434-64de72199155?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D";
const imgURL =
  "https://images.pexels.com/photos/1366919/pexels-photo-1366919.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1";
const GroupCard = () => {
  return (
    <div className="w-full flex flex-row shadow text-card-foreground bg-card">
      <div className="flex items-center justify-center p-2 w-32">
        <img
          className=" aspect-square object-cover rounded-full"
          src={imgURL}
        />
      </div>
      <div className="flex flex-col w-full">
        <h2 className="font-normal text-lg">The best people</h2>
        <p className="font-extralight text-sm">4 members</p>
        <p className="font-light text-md text-end">Total owed:</p>
        <p className="font-bold text-2xl text-end">32,42 €</p>
      </div>
    </div>
  );
};

export default GroupCard;
