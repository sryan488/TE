using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Exercises.Tests
{
    [TestClass]
    public class StringBitsTests

    {
        [TestMethod]
        public void GetBits()
        {

            // Arrange
            StringBits ex = new StringBits();

            // Act
            string actualResult = ex.GetBits("Hello");

            // Assert
            Assert.AreEqual("Hlo", actualResult);
        }
        [DataTestMethod]
        [DataRow("Hi", "H")]
        [DataRow("Heeololeo", "Hello")]
        public void DataTestGetBits(string input1, string expectedResult)
        {
            // Arrange
            StringBits ex = new StringBits();

            // Act
            string actualResult = ex.GetBits(input1);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}

