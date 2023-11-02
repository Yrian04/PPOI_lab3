using PPOIS3.Exceptions;
namespace PPOIS3.Tests
{
    [TestClass()]
    public class ItemTests
    {
        [TestMethod()]
        public void GetPriceWithDiscountTest()
        {
            //arrange
            var item = new Item("Item", 10, 1);
            var discount = new ItemDiscount(0.5);
            item.Discounts.Add(discount);

            //act
            var actual = item.GetPriceWithDiscount();

            //assert
            var expected = item.Price * item.Number * item.Discounts[0].Value;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetItemTest()
        {
            //arrange
            var item = new Item("Item", 10, 3);
            var expected = new Subitem(item, item.Id, item.Name, item.Price, 1);

            //act
            var actual = item.GetItem(1);

            //assert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Price, actual.Price);
            Assert.AreEqual(expected.Superitem, actual.Superitem);
            Assert.AreEqual(expected.Number, actual.Number);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void GetItemTest_ArgumentException()
        {
            //arrange
            var item = new Item("Item", 10, 3);

            //act
#pragma warning disable IDE0059 // Ненужное присваивание значения
            var actual = item.GetItem(0);
#pragma warning restore IDE0059 // Ненужное присваивание значения
        }

        [TestMethod, ExpectedException(typeof(NotEnoughItemsException))]
        public void GetItemTest_NotEnoughItemsException()
        {
            //arrange
            var item = new Item("Item", 10, 3);

            //act
#pragma warning disable IDE0059 // Ненужное присваивание значения
            var actual = item.GetItem(5);
#pragma warning restore IDE0059 // Ненужное присваивание значения
        }

        [TestMethod()]
        public void ReturnSubitemTest()
        {
            //arrange
            var item = new Item("Item", 10, 3);
            var subitem = item.GetItem(1);

            //act
            var flag = item.ReturnSubitem(subitem);

            //assert
            Assert.IsTrue(flag);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ReturnSubitemTest_ArgumentException()
        {
            //arrange
            var item = new Item("Item", 10, 3);
            var item1 = new Item("Item1", 10, 3);
            var subitem = item1.GetItem(1);

            //act
            item.ReturnSubitem(subitem);
        }

        [TestMethod()]
        public void TakeSubitemTest()
        {
            //arrange
            var item = new Item("Item", 10, 3);
            var subitem = item.GetItem(1);

            //act
            var flag = item.TakeSubitem(subitem);

            //assert
            Assert.IsTrue(flag);
            Assert.AreEqual(2u, item.Number);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TakeSubitemTest_ArgumentException()
        {
            //arrange
            var item = new Item("Item", 10, 3);
            var item1 = new Item("Item1", 10, 3);
            var subitem = item1.GetItem(1);

            //act
            item.ReturnSubitem(subitem);
        }
    }
}