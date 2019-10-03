using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Exercises.Tests
{
    [TestClass]
    public class NonStartTests

    {
        [TestMethod]
        public void GetPartialString()
        {

            // Arrange
            NonStart ex = new NonStart();

            // Act
            string actualResult = ex.GetPartialString("Hello", "There");

            // Assert
            Assert.AreEqual("ellohere", actualResult);

        }

        [DataTestMethod]
        [DataRow("java", "code", "avaode")]
        [DataRow("shotl", "java", "hotlava")]

        public void DataTestGetPartialString(string input1, string input2, string expectedResult)
        {
            // Arrange
            NonStart ex = new NonStart();

            // Act
            string actualResult = ex.GetPartialString(input1, input2);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
