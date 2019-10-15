using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class KataPotterTests
    {
        [TestMethod]
        public void TestPotter(double expectedResult, int[] books)
        {
            // Arrange
            // Create a new Potter object
            KataPotter subject = new KataPotter();

            // Act
            double actualResult = subject.GetCost(books);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);


        }
    }
}
