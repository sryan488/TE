using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Exercises.Tests
{
    [TestClass]
    public class FrontTimesTests

    {
        [TestMethod]
        public void GenerateString()
        {

            // Arrange
            FrontTimes ex = new FrontTimes();

            // Act
            string actualResult = ex.GenerateString("Chocolate", 2);

            // Assert
            Assert.AreEqual("ChoCho", actualResult);
        }
        [DataTestMethod]
        [DataRow("Chocolate", 3, "ChoChoCho")]
        [DataRow("Abc", 3, "AbcAbcAbc")]
        public void DataTestGenerateString(string input1, int input2, string expectedResult)
        {
            // Arrange
            FrontTimes ex = new FrontTimes();

            // Act
            string actualResult = ex.GenerateString(input1, input2);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}