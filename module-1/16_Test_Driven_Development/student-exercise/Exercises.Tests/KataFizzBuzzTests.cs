using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class KataFizzBuzzTests
    {
        [DataTestMethod]
        [DataRow(1, "1")]
        public void TestFizzBuzz(int numberToTest, string expectedResult)
        {
            // Arrange
            KataFizzBuzz subject = new KataFizzBuzz();

            // Act
            string actualFB = subject.ToFizzBuzz(numberToTest);

            // Assert
            Assert.AreEqual(expectedResult, actualFB);
        }


    }
}
