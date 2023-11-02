using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PPOIS3.Tests")]

namespace PPOIS3
{
public class Subitem : Item
{
        public Item Superitem { get; init; }
        internal Subitem(Item superitem, uint number) : this(
            superitem,
            superitem.Id,
            superitem.Name,
            superitem.Price,
            number) { }
        internal Subitem(
            Item superitem,
            int id,
            string name,
            double price,
            uint number) : base(name, price, number)
        {
            Id = id;
            Superitem = superitem;
        }
    }
}