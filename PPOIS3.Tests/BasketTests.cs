namespace PPOIS3.Tests
{
    [TestClass()]
    public class BasketTests
    {
        [TestMethod]
        public void BasketTest()
        {
            //arrange
            var subitems = new List<Subitem>()
            {
                new Subitem(new Item("Item1", 2.5, 4),  4),
                new Subitem(new Item("Item2", 5, 2),  2),
                new Subitem(new Item("Item3", 10, 1),  1)
            };
            var owner = new Client("Owner");

            var expected = new Basket(owner);
            foreach (var item in subitems)
                expected.Add(item);

            //act
            var actual = new Basket(owner, subitems.ToArray());

            //assert
            Assert.AreEqual(expected.Owner, actual.Owner);
            foreach (var item in expected)
                Assert.IsTrue(actual.Contains(item));
        }
    }
}