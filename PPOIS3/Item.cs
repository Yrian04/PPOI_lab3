namespace PPOIS3
{
    public class Item
    {
        private static int nextId = 0;
        public int Id { get; init; }
        public string Name {  get; set; }
        public double Price { get; set; }

        private uint _number;
        public uint Number
        {
            get
            {
                uint number = this._number;
                foreach (var subitem in _subitems)
                    number -= subitem.Number;

                return number;
            }

            set
            {
                if (value == 0)
                    throw new ArgumentException("Number of items must be natural number", nameof(value));

                _number = value;
            }
        }
        private readonly List<Subitem> _subitems = new();
        public List<ItemDiscount> Discounts = new();
        public Item(string name, double price, uint number)
        {
            Id = nextId++;
            Name = name;
            Price = price;
            Number = number;
        }
        public double GetPriceWithDiscount() 
        {
            double price = Price * Number;
            foreach (ItemDiscount discount in Discounts)
                price = discount.Apply(this);

            return price;
        }
        public Subitem GetItem(uint number)
        {
            if (number == 0)
                throw new ArgumentException("Number of items must be positive number", nameof(number));
            if (number > Number)
                throw new NotEnoughItemsException();

            Subitem subitem = new(this, Id, Name, Price, number);
            _subitems.Add(subitem);

            return subitem;
        }
        public bool ReturnSubitem(Subitem subitem)
        {
            if (!_subitems.Contains(subitem))
                throw new ArgumentException("Subitem is not contains in item", nameof(subitem));
        
            if (subitem.Id != Id)
                throw new ArgumentException("Subitem ID not equals item ID", nameof(subitem));

            return _subitems.Remove(subitem);
        }

        public bool TakeSubitem(Subitem subitem)
        {
            if (!_subitems.Contains(subitem))
                throw new ArgumentException("Subitem is not contains in item", nameof(subitem));

            if (subitem.Id != Id)
                throw new ArgumentException("Subitem ID not equals item ID", nameof(subitem));

            _number -= subitem.Number;

            return _subitems.Remove(subitem);
        }
    }
}