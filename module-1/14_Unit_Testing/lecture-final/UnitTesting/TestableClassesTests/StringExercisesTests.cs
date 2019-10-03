using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestableClasses.Classes;

namespace TestableClassesTests
{
    [TestClass]
    public class StringExercisesTests
    {
        
        private StringExercises ex;

        [TestInitialize]
        public void InitializeTests()
        {
            this.ex = new StringExercises();
        }

        [TestMethod]
        public void TestMakeAbba1()
        {
            //makeAbba("Hi", "Bye")  "HiByeByeHi"
            //makeAbba("Yo", "Alice")  "YoAliceAliceYo"
            //makeAbba("What", "Up")  "WhatUpUpWhat"

            // Arrange
            // Create an instance of StringExercises

            // Act
            string actualResult = ex.MakeAbba("Hi", "Bye");

            // Assert
            Assert.AreEqual("HiByeByeHi", actualResult);

        }

        [TestMethod]
        public void TestMakeAbbaSpaceFirstString()
        {
            //Arrange

            // Act
            string actualResult = ex.MakeAbba(" ", "Yeah");

            // Assert
            Assert.AreEqual(" YeahYeah ", actualResult);
        }

        [DataTestMethod]
        [DataRow("Hi", "Bye", "HiByeByeHi", DisplayName ="Hi-Bye")]
        [DataRow(" ", "Yeah", " YeahYeah ", DisplayName = "blank-Yeah")]
        [DataRow("", "", "", DisplayName = "Empty strings")]
        [DataRow(" ", " ", "    ", DisplayName = "Blank strings")]
        public void DataTestMakeAbba(string input1, string input2, string expectedResult)
        {
            // Arrange

            // Act
            string actualResult = ex.MakeAbba(input1, input2);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);

        }
    }
}
