namespace PPOIS3.Processors
{
    public class ConsoleViewer : IViewer
    {
        public void View(Item item)
        {
            Console.WriteLine(item.Name);
            Console.WriteLine($"ID: {item.Id}");
            Console.WriteLine($"Price: {item.Price}");
            Console.WriteLine($"Number: {item.Number}");
            Console.WriteLine("---------------------");
        }
        public void View(Basket basket)
        {
            foreach (var item in basket)
                View(item);
        }
        public void View(Client client)
        {
            Console.WriteLine(client.Name);
            Console.WriteLine("Basket:");
            View(client.Basket);
        }
    }
}
