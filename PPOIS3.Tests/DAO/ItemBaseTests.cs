using Microsoft.VisualStudio.TestTools.UnitTesting;
using PPOIS3.DAO;
using PPOIS3.Exceptions;

namespace PPOIS3.DAO.Tests
{
    [TestClass()]
    public class ItemBaseTests
    {
        [TestMethod()]
        public void ExistsTest()
        {
            //arrange
            _ = new ItemBase();
            var item = new Item("Item", 10, 10);
            ItemBase.Instance!.Create(item);

            //act
            var flag = ItemBase.Instance!.Exists(item);

            //assert
            Assert.IsTrue(flag);
        }

        [TestMethod()]
        public void ExistsTest_ItemIsNotExists()
        {
            //arrange
            _ = new ItemBase();
            var item = new Item("Item", 10, 10);

            //act
            var flag = ItemBase.Instance!.Exists(item);

            //assert
            Assert.IsFalse(flag);
        }

        [TestMethod()]
        public void IdExistsTest()
        {
            //arrange
            _ = new ItemBase();
            var item = new Item("Item", 10, 10);
            ItemBase.Instance!.Create(item);

            //act
            var flag = ItemBase.Instance!.Exists(item.Id);

            //assert
            Assert.IsTrue(flag);
        }

        [TestMethod()]
        public void IdExistsTest_ItemIsNotExists()
        {
            //arrange
            _ = new ItemBase();
            var item = new Item("Item", 10, 10);

            //act
            var flag = ItemBase.Instance!.Exists(item.Id+1);

            //assert
            Assert.IsFalse(flag);
        }

        [TestMethod()]
        public void CreateTest()
        {
            //arrange
            _ = new ItemBase();
            var item = new Item("Item", 10, 10);

            //act
            ItemBase.Instance!.Create(item);

            //assert
            Assert.IsTrue(ItemBase.Instance!.Exists(item.Id));
        }

        [TestMethod()]
        public void GetTest()
        {
            //arrange
            _ = new ItemBase();
            var item = new Item("Item", 10, 10);
            var id = ItemBase.Instance!.Create(item);

            //act
            var subitem = ItemBase.Instance!.Get(id, 3);

            //assert
            Assert.IsNotNull(subitem);
            Assert.AreEqual(7u, item.Number);
            Assert.AreEqual(3u, subitem.Number);
        }

        [TestMethod, ExpectedException(typeof(NotEnoughItemsException))]
        public void GetTest_NotEnoughItemsException()
        {
            //arrange
            _ = new ItemBase();
            var item = new Item("Item", 10, 10);
            var id = ItemBase.Instance!.Create(item);

            //act
            ItemBase.Instance!.Get(id, 20);
        }

        [TestMethod()]
        public void GetTest_ReturnNull()
        {
            //arrange
            _ = new ItemBase();
            var item = new Item("Item", 10, 10);
            var id = ItemBase.Instance!.Create(item);

            //act
            var subitem = ItemBase.Instance!.Get(id+1, 3);

            //assert
            Assert.IsNull(subitem);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            //arrange
            _ = new ItemBase();
            var item = new Item("Item", 10, 10);
            var id = ItemBase.Instance!.Create(item);

            //act
            var flag = ItemBase.Instance!.Remove(id);

            //assert
            Assert.IsTrue(flag);
        }

        [TestMethod()]
        public void RemoveTest_IdIsNotExists()
        {
            //arrange
            _ = new ItemBase();
            var item = new Item("Item", 10, 10);
            var id = ItemBase.Instance!.Create(item);

            //act
            var flag = ItemBase.Instance!.Remove(id+1);

            //assert
            Assert.IsFalse(flag);
        }

        [TestMethod()]
        public void TakeTest()
        {
            //arrange
            _ = new ItemBase();
            var item = new Item("Item", 10, 10);
            var id = ItemBase.Instance!.Create(item);
            var subitem = ItemBase.Instance.Get(id, 3);

            //act
            var flag = ItemBase.Instance.Take(subitem!);

            //assert
            Assert.IsTrue(flag);
            Assert.AreEqual(7u, item.Number);
        }
    }
}