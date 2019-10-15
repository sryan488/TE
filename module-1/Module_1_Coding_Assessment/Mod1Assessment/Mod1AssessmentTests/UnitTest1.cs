using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mod1Assessment;


namespace Mod1AssessmentTests
{
    [TestClass]
    public class FlowerShopOrderTest
    {
        [TestMethod]
        public void TestSubtotal()
        {
            // Arrange

            FlowerShopOrder ex = new FlowerShopOrder("vase", 12);

            //FlowerShopOrder ex = new FlowerShopOrder("flowers", 12);

            // Act
            decimal actualResult = ex.Subtotal;

            // Assert
            Assert.AreEqual(55.87M, actualResult);
        }

        [DataTestMethod]
        [DataRow(true, "20000", 9.98)]
        [DataRow(false, "20000", 3.99)]
        public void TestTotal(bool sameDayDelivery, string zipCode, double expectedResult)
        {
            FlowerShopOrder fso = new FlowerShopOrder("vase", 12);

            decimal actualResult = fso.GrandTotal(sameDayDelivery, zipCode);

            decimal expectedDecimalResult = decimal.Parse(expectedResult.ToString());

            Assert.AreEqual(expectedDecimalResult, actualResult);
        }
    }
}
