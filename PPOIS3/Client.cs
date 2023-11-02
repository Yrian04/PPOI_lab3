using PPOIS3.DAO;

namespace PPOIS3
{
    public class Client
    {
        public string Name { get; set; }
        public Basket Basket { get; init; }
        public List<ClientDiscount> Discounts { get; init; }

        internal Client(string name)
        {
            Name = name;
            Basket = new Basket(this);
            Discounts = new List<ClientDiscount>();
        }

        public bool AddDiscount(ClientDiscount discount)
        {
            if(Discounts.Contains(discount))
                return false;

            Discounts.Add(discount);

            return true;
        }

        public bool RemoveDiscount(ClientDiscount discount) => Discounts.Remove(discount);

        public virtual bool BuyBasket()
        {
            bool success = true;

            foreach (var item in Basket)
                success &= ItemBase.Instance?.Take(item) ?? false;

            return success;
        }

        public override string ToString() => Name;
    }
}
