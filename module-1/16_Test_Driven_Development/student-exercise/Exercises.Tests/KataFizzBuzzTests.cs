﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        [DataRow(3, "Fizz")]
        [DataRow(13, "Fizz")]
        [DataRow(35, "FizzBuzz")]
        [DataRow(5, "Buzz")]
        [DataRow(51, "Fizz")] //Because 51 is divisible by 3
        [DataRow(53, "FizzBuzz")]
        [DataRow(0, "")]
        public void TestFizzBuzzForFizz(int numberToTest, string expectedResult)
        {
            // Arrange
            KataFizzBuzz fizz = new KataFizzBuzz();
            // Act
            string actualFB = fizz.ToFizzBuzz(numberToTest);

            // Assert
            Assert.AreEqual(expectedResult, actualFB);
        }
        
        
        #region
        //public void TestFizzBuzzForOne(int numberToTest, string expectedResult)
        //{
        //    // Arrange
        //    KataFizzBuzz subject = new KataFizzBuzz();

        //    // Act
        //    string actualFB = subject.ToFizzBuzz(1);

        //    // Assert
        //    Assert.AreEqual("1", actualFB);
        #endregion
    }


}
