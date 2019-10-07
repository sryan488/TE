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
        [TestMethod]
        [DataRow(1, "1")]
        public void TestFizzBuzzForOne(int numberToTest, string expectedResult)
        {
            // Arrange
            KataFizzBuzz subject = new KataFizzBuzz();

            // Act
            string actualFB = subject.ToFizzBuzz(1);

            // Assert
            Assert.AreEqual("1", actualFB);
        }


    }
}
