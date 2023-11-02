namespace PPOIS3.DAO
{
    public class ItemBase
    {
        private readonly List<Item> items = new();
        public static ItemBase? Instance { get; private set; }

        public ItemBase() => Instance ??= this;

        public virtual bool Exists(Item item) => Exists(item.Id);
        public virtual bool Exists(int id) => items.Exists(x => x.Id == id);

        public virtual int Create(Item item)
        {
            if (Exists(item))
                throw new ArgumentException("Item ia already exists", nameof(item));

            items.Add(item);

            return item.Id;
        }

        public virtual Subitem? Get(int id, uint number)
        {
            Item? item = items.Find(x => x.Id == id);
            if (item is null)
                return null;

            if (item.Number < number)
                throw new NotEnoughItemsException();

            return item.GetItem(number);
        }

        public virtual bool Remove(int id)
        {
            Item? item = items.Find(x => x.Id == id);
            if (item is null)
                return false;

            return items.Remove(item);
        }

        public virtual bool Take(Subitem subitem)
        {
            Item item = subitem.Superitem;
            if (!items.Contains(item))
                throw new SuperitemException();

            bool flag = item.TakeSubitem(subitem);

            if (flag && item.Number == 0)
                items.Remove(item);

            return flag;
        }
    }
}
