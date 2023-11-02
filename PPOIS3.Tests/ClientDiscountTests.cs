namespace PPOIS3.Tests
{
    [TestClass()]
    public class ClientDiscountTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(1.5)]
        [DataRow(0.0)]
        [DataRow(1.0)]
        [DataRow(-1.0)]
        public void SetValueTes_ArgumentOutOfRangeException(double value)
        {
            //arrange
#pragma warning disable IDE0017 // Упростите инициализацию объекта
            var discount = new ClientDiscount(0.5);
#pragma warning restore IDE0017 // Упростите инициализацию объекта

            //act
            discount.Value = value;
        }

        [TestMethod()]
        public void ApplyTest()
        {
            //arrange
            var client = new Client("Client");
            var discount = new ClientDiscount(0.1);

            var subitems = new List<Subitem>()
            {
                new Subitem(new Item("Item1", 2.5, 4),  4),
                new Subitem(new Item("Item2", 5, 2),  2),
                new Subitem(new Item("Item3", 10, 1),  1)
            };

            foreach (var Subitem in subitems)
                client.Basket.Add(Subitem);

            var expected = 3d;

            //act
            var actual = discount.Apply(client.Basket);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            //arrange
            var discount = new ClientDiscount(0.5);
            var expected = "0,5";

            //act
            var actual = discount.ToString();
            
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}