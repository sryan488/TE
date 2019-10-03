using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestableClasses.Classes;

namespace TestableClassesTests
{
    [TestClass]
    public class LoopsAndArrayExercisesTest
    {
        [TestMethod]
        public void MiddleWayTest()
        {
            // Arrange
            LoopsAndArrayExercises ex = new LoopsAndArrayExercises();

            // Act
            int[] actualResult = ex.MiddleWay(new int[]{ 1, 2, 3}, new int[]{ 4, 5, 6 });

            // Assert
            Assert.AreEqual(2, actualResult.Length);

            CollectionAssert.AreEqual(new int[] { 2, 5 }, actualResult);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 2, 5 }, DisplayName = "1-2-3, 4-5-6")]
        [DataRow(new int[] { 10, 20, 30 }, new int[] { 40, 20, 60 }, new int[] { 20, 20 }, DisplayName = "10-20-30, 40-20-60")]
        public void MiddleWayDataTest(int[] a, int[] b, int[] expectedResult)
        {
            // Arrange
            LoopsAndArrayExercises ex = new LoopsAndArrayExercises();

            // Act
            int[] actualResult = ex.MiddleWay(a, b);

            // Assert
            Assert.AreEqual(2, actualResult.Length);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }

}6556
