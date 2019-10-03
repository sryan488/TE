using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Exercises.Tests
{
    [TestClass]
    public class Less20Tests

    {
        [TestMethod]
        public void IsLessThanMultipleOf20()
        {

            // Arrange
            Less20 ex = new Less20();

            // Act
            bool actualResult = ex.IsLessThanMultipleOf20(18);

            // Assert
            Assert.AreEqual(true, actualResult);
        }
        [DataTestMethod]
        [DataRow(19, true)]
        [DataRow(20, false)]
        public void DataTestIsLessThanMultipleOf20(int input1, bool expectedResult)
        {
            // Arrange
            Less20 ex = new Less20();

            // Act
            bool actualResult = ex.IsLessThanMultipleOf20(input1);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}