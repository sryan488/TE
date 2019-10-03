using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Exercises.Tests
{
    [TestClass]
    public class SameFirstLastTests

    {
        [TestMethod]
        public void IsItTheSame()
        {

            // Arrange
            SameFirstLast ex = new SameFirstLast();

            // Act
            bool actualResult = ex.IsItTheSame(new int[] { 1, 2, 3 });

            // Assert
            Assert.AreEqual(false, actualResult);
        }
        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3, 1 }, true)]
        [DataRow(new int[] { 1, 2, 1 }, true)]
        public void DataTestSameFirstLast(int[] input1, bool expectedResult)
        {
            // Arrange
            SameFirstLast ex = new SameFirstLast();

            // Act
            bool actualResult = ex.IsItTheSame(input1);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}