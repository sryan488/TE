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
       // [DataTestMethod]
        //[DataRow(true, true, 68.99)]
        //[DataRow(true, false, 132.97)]
        //[DataRow(false, true, 202.92)]
        //[DataRow(false, false, 119.98)]
       // public void TestActualTotal(bool usedMinibar, bool requiresCleaning, decimal expectedResult)
        //{
         //   HotelReservation hr = new HotelReservation("Tommy", 2);

         //   decimal actaulResult = hr.AdditionalFees(usedMinibar, requiresCleaning);

         //   decimal expectedDecimalResult = decimal.Parse(expectedResult.ToString());

          //  Assert.AreEqual(expectedResult, actaulResult);
        //}
    }
}
