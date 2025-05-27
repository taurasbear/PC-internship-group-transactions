import { Button } from "../ui/button";

const MemberCard = () => {
  return (
    <div className="bg-card relative flex w-full flex-row shadow">
      <div className="absolute pt-1 pl-1">
        <Button className="h-4 p-0" variant="secondary">
          X
        </Button>
      </div>
      <div className="flex w-32 items-center justify-center p-2">
        <img
          src="https://shop.wwf.ca/cdn/shop/files/grizzly-bear-WW199558.jpg?v=1694540462"
          alt="Bear profile"
          className="aspect-square rounded-full object-cover"
        />
      </div>

      <div className="flex w-full flex-col p-2">
        <h2 className="text-lg font-normal">Timmy Parker</h2>
        <p className="text-md font-light">Owes you</p>
        <p className="text-end text-2xl font-bold">2.42 €</p>
        <div className="flex w-full justify-end">
          <Button className="h-6 w-20 rounded-xl text-sm" variant="contained">
            Settle
          </Button>
        </div>
      </div>
    </div>
  );
};

export default MemberCard;
