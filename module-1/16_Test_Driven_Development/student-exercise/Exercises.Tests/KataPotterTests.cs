using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class KataPotterTests
    {
        [TestMethod]
        public void TestPotter(double expectedResult, int[] numberOfBooks)
        {
            // Arrange
            // Create a new Potter object
            KataPotter subject = new KataPotter();

            // Act
            double actualResult = subject.GetCost(numberOfBooks);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);


        }
    }
}
