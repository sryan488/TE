using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Exercises.Tests
{
    [TestClass]
    public class Lucky13Tests

    {
        [TestMethod]
        public void GetLucky()
        {

            // Arrange
            Lucky13 ex = new Lucky13();

            // Act
            bool actualResult = ex.GetLucky(new int[] { 0, 2, 4 });

            // Assert
            Assert.AreEqual(true, actualResult);
        }
        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 }, false)]
        [DataRow(new int[] { 1, 2, 4 }, false)]
        public void DataTestGetLucky(int[] input1, bool expectedResult)
        {
            // Arrange
            Lucky13 ex = new Lucky13();

            // Act
            bool actualResult = ex.GetLucky(input1);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
