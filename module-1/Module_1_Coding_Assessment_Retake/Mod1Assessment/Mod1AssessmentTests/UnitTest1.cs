using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mod1Assessment;

namespace Mod1AssessmentTests
{
    [TestClass]
    public class HotelReservationTest
    {
        [TestMethod]
        public void TestEstimatedTotal()
        {
            // Arrange
            HotelReservation ex = new HotelReservation("Billy", 2);

            // Act
            decimal actualResult = ex.EstimatedTotal;
            // Assert
            Assert.AreEqual(119.98M, actualResult);
        }
        [DataTestMethod]
        [DataRow(true, true, 82.97)]
        [DataRow(true, false, 34.99)]
        [DataRow(false, true, 12.99)]
        [DataRow(false, false, 0.00)]
        public void TestActualTotal(bool usedMinibar, bool requiresCleaning, double expectedResult)
        {
            HotelReservation hr = new HotelReservation("Tommy", 1);

            decimal actaulResult = hr.AdditionalFees(usedMinibar, requiresCleaning);

            decimal expectedDecimalResult = decimal.Parse(expectedResult.ToString());

            Assert.AreEqual(expectedDecimalResult, actaulResult);
        }
    }
}
