using Microsoft.VisualStudio.TestTools.UnitTesting;
using PPOIS3.DAO;

namespace PPOIS3.DAO.Tests
{
    [TestClass()]
    public class ClientBaseTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            //arrange
            _ = new ClientBase();

            //act
            var flag = ClientBase.Instance!.Create(new Client("Client"));

            //assert
            Assert.IsTrue(flag);
        }

        [TestMethod()]
        public void CreateTest_ClientAlreadyExists()
        {
            //arrange
            _ = new ClientBase();
            ClientBase.Instance!.Create(new Client("Client"));

            //act
            var flag = ClientBase.Instance!.Create(new Client("Client"));

            //assert
            Assert.IsFalse(flag);
        }

        [TestMethod()]
        public void GetTest()
        {
            //arrange
            _ = new ClientBase();
            var expected = new Client("Client");
            ClientBase.Instance!.Remove("Client");
            ClientBase.Instance!.Create(expected);

            //act
            var actual = ClientBase.Instance!.Get("Client");

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            //arrange
            _ = new ClientBase();
            ClientBase.Instance!.Create(new Client("Client"));

            //act
            var flag = ClientBase.Instance!.Remove("Client");

            //assert
            var actual = ClientBase.Instance!.Get("Client");
            Assert.AreEqual(null, actual);
            Assert.IsTrue(flag);
        }
#pragma warning disable CA1822 // Пометьте члены как статические
        public void RemoveTest_ClientIsNotExists()
#pragma warning restore CA1822 // Пометьте члены как статические
        {
            //arrange
            _ = new ClientBase();
            ClientBase.Instance!.Remove("Client");

            //act
            var flag = ClientBase.Instance!.Remove("Client");

            //assert
            var actual = ClientBase.Instance!.Get("Client");
            Assert.AreEqual(null, actual);
            Assert.IsFalse(flag);
        }
    }
}