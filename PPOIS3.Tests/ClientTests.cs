using PPOIS3.DAO;

namespace PPOIS3.Tests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void AddDiscountTest()
        {
            //arrange
            var discount = new ClientDiscount(0.5);
            var client = new Client("Client");
            
            //act
            var flag = client.AddDiscount(discount);

            //assert
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void AddDiscountDoubleAddingTest()
        {
            //arrange
            var discount = new ClientDiscount(0.5);
            var client = new Client("Client");
            client.AddDiscount(discount);

            //act
            var flag = client.AddDiscount(discount);

            //assert
            Assert.IsFalse(flag);
        }

        [TestMethod]
        public void RemoveDiscountTest()
        {
            //arrange
            var discount = new ClientDiscount(0.5);
            var client = new Client("Client");
            client.AddDiscount(discount);

            //act
            var flag = client.RemoveDiscount(discount);

            //assert
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void BuyBasketTest()
        {
            //arrange
            _ = new ItemBase();
            int id = ItemBase.Instance!.Create(new Item("Item", 10, 10));
            var items = new List<Subitem>() { 
                ItemBase.Instance!.Get(id, 3) ?? throw new NullReferenceException(),
                ItemBase.Instance!.Get(id, 3) ?? throw new NullReferenceException(), 
                ItemBase.Instance!.Get(id, 3) ?? throw new NullReferenceException() };
            var client = new Client("Client");
            foreach (var item in items) 
                client.Basket.Add(item);

            //act
            var flag = client.BuyBasket();

            //assert
            Assert.IsTrue(flag);
        }
    }
}