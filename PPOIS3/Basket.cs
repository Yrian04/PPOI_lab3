using System.Collections;

namespace PPOIS3
{
    public class Basket : ICollection<Subitem>
    {
        private readonly List<Subitem> items = new();
        public Client Owner { get; init; }
        public double Price
        {
            get
            {
                double price = 0;
                foreach (Subitem item in items) price += item.GetPriceWithDiscount();

                return price;
            }
        }

        public Basket(Client owner, params Subitem[] items) : this(owner) 
            => this.items = new List<Subitem>(items);

        public Basket(Client owner) => Owner = owner;

        public int Count => ((ICollection<Subitem>)items).Count;

        public bool IsReadOnly => ((ICollection<Subitem>)items).IsReadOnly;

        public void Add(Subitem item) => ((ICollection<Subitem>)items).Add(item);

        public void Clear() => ((ICollection<Subitem>)items).Clear();

        public bool Contains(Subitem item)
            => ((ICollection<Subitem>)items).Contains(item);

        public void CopyTo(Subitem[] array, int arrayIndex)
            => ((ICollection<Subitem>)items).CopyTo(array, arrayIndex);

        public IEnumerator<Subitem> GetEnumerator()
            => ((IEnumerable<Subitem>)items).GetEnumerator();

        public bool Remove(Subitem item) => ((ICollection<Subitem>)items).Remove(item);

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)items).GetEnumerator();
    }
}
