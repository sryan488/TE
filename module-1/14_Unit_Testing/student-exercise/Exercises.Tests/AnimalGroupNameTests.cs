using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Exercises.Tests
{
    [TestClass]
    public class AnimalGroupNameTests

    {
        [TestMethod]
        public void GetHerd()
        {

            // Arrange
            AnimalGroupName ex = new AnimalGroupName();

            // Act
            string actualResult = ex.GetHerd("giraffe");

            // Assert
            Assert.AreEqual("Tower", actualResult);

        }

        [DataTestMethod]
        [DataRow("", "unknown")]
        [DataRow("walrus", "unknown")]
        [DataRow("Rhino", "Crash")]
        [DataRow("rhino", "Crash")]
        [DataRow("elephants", "unknown")]
        public void DataTestGetHerd(string input1, string expectedResult)
        {
            // Arrange
            AnimalGroupName ex = new AnimalGroupName();

            // Act
            string actualResult = ex.GetHerd(input1);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
