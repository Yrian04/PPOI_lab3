using Microsoft.VisualStudio.TestTools.UnitTesting;
using PPOIS3.Processors;

namespace PPOIS3.Processors.Tests
{
    [TestClass()]
    public class ConsoleViewerTests
    {
        [TestMethod()]
        public void ViewItemTest()
        {
            //arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var item = new Item("Item", 10, 10);
            var viewer = new ConsoleViewer();

            //act
            viewer.View(item);

            //assert
            var actual = stringWriter.ToString();
            var expected = $"""
                {item.Name}
                ID: {item.Id}
                Price: {item.Price}
                Number: {item.Number}
                ---------------------

                """;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ViewBasketTest()
        {
            //arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var items = new List<Subitem>()
            {
                new Subitem(new Item("Item1", 10, 30), 30),
                new Subitem(new Item("Item2", 20, 20), 20),
                new Subitem(new Item("Item3", 30, 10), 10)
            };
            var basket = new Basket(new Client("Client"), items.ToArray());
            var viewer = new ConsoleViewer();

            //act
            viewer.View(basket);

            //assert
            var actual = stringWriter.ToString();
            var expected = ""; 
            foreach (var item in items)
                expected += $"""
                {item.Name}
                ID: {item.Id}
                Price: {item.Price}
                Number: {item.Number}
                ---------------------

                """; 

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ViewClientTest()
        {
            //arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var items = new List<Subitem>()
            {
                new Subitem(new Item("Item1", 10, 30), 30),
                new Subitem(new Item("Item2", 20, 20), 20),
                new Subitem(new Item("Item3", 30, 10), 10)
            };

            var client = new Client("Client");
            
            foreach (var item in items)
                client.Basket.Add(item);

            var viewer = new ConsoleViewer();

            //act
            viewer.View(client);

            //assert
            var actual = stringWriter.ToString();
            var expected = $"""
                {client.Name}
                Basket:

                """;
            foreach (var item in items)
                expected += $"""
                {item.Name}
                ID: {item.Id}
                Price: {item.Price}
                Number: {item.Number}
                ---------------------

                """;

            Assert.AreEqual(expected, actual);
        }
    }
}