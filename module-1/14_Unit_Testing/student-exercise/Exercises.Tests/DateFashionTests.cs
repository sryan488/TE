using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises
{
    [TestClass]
    public class DateFashionTests
    {
        [TestMethod]
        public void GetATable()
        {
            // Arrange
            DateFashion ex = new DateFashion();

            // Act
            int actualResult = ex.GetATable(5, 10);

            // Assert
            Assert.AreEqual(2, actualResult);
        }
        [DataTestMethod]
        [DataRow(5, 2, 0)]
        [DataRow(5, 5, 1)]
        public void DataTestGetATable(int input1, int input2, int expectedResult)
        {
            // Arrange
            DateFashion ex = new DateFashion();

            // Act
            int actualResult = ex.GetATable(input1, input2);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
