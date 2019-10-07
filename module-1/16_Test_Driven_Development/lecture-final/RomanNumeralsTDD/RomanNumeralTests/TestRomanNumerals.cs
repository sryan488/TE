using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumeralsTDD;

namespace RomanNumeralTests
{
    [TestClass]
    public class TestRomanNumerals
    {
        [DataTestMethod]
        [DataRow(1, "I")]
        [DataRow(5, "V")]
        [DataRow(10, "X")]
        [DataRow(50, "L")]
        [DataRow(100, "C")]
        [DataRow(500, "D")]
        [DataRow(1000, "M")]
        [DataRow(2, "II")]
        [DataRow(3, "III")]
        [DataRow(200, "CC")]
        [DataRow(3000, "MMM")]
        public void TestRomanNumeral(int numberToTest, string expectedResult)
        {
            // Arrange
            // Create a new RomanNumeral object
            RomanNumeral roman = new RomanNumeral();

            // Act
            string actualRN = roman.ToRoman(numberToTest);

            // Assert
            Assert.AreEqual(expectedResult, actualRN);

        }

        //[TestMethod]
        //public void TestRomanNumeralForOne()
        //{
        //    // Arrange
        //    // Create a new RomanNumeral object
        //    RomanNumeral roman = new RomanNumeral();

        //    // Act
        //    string actualRN = roman.ToRoman(1);


        //    // Assert
        //    Assert.AreEqual("I", actualRN);
        
        //}

        //[TestMethod]
        //public void TestRomanNumeralForFive()
        //{
        //    // Arrange
        //    // Create a new RomanNumeral object
        //    RomanNumeral roman = new RomanNumeral();

        //    // Act
        //    string actualRN = roman.ToRoman(5);


        //    // Assert
        //    Assert.AreEqual("V", actualRN);

        //}

    }
}
