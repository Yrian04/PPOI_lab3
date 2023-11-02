namespace PPOIS3.Tests
{
    [TestClass()]
    public class ItemDiscountTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            //arrange
            var discount = new ItemDiscount(0.5);
            var expected = "0,5";

            //act
            var actual = discount.ToString();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(1.5)]
        [DataRow(0.0)]
        [DataRow(1.0)]
        [DataRow(-1.0)]
        public void SetValueTest_ArgumentOutOfRangeException(double value)
        {
            //arrange
#pragma warning disable IDE0017 // Упростите инициализацию объекта
            var discount = new ItemDiscount(0.5);
#pragma warning restore IDE0017 // Упростите инициализацию объекта

            //act 
            discount.Value = value;
        }

        [TestMethod()]
        public void ApplyTest()
        {
            //arrange
            var item = new Item("Item", 10, 2);
            var discount = new ItemDiscount(0.5);
            var expected = 10d;

            //act
            var actual = discount.Apply(item);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}