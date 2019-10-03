using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Exercises.Tests
{
    [TestClass]
    public class MaxEndTests

    {
        [TestMethod]
        public void MakeArray()
        {

            // Arrange
            MaxEnd3 ex = new MaxEnd3();

            // Act
            int[] actualResult = ex.MakeArray(new int[]{1, 2, 3});

            // Assert
            CollectionAssert.AreEqual(new int[]{3, 3, 3}, actualResult);
        }
        [DataTestMethod]
        [DataRow(new int[]{11, 5, 9}, new int[]{11, 11, 11 })]
        [DataRow(new int[]{2, 11, 3}, new int[]{3, 3, 3})]
        public void DataTestMakeArray(int[] input1, int[] expectedResult)
        {
            // Arrange
            MaxEnd3 ex = new MaxEnd3();

            // Act
            int[] actualResult = ex.MakeArray(input1);

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}