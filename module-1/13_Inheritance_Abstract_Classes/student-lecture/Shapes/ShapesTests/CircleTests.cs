using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Models;
using System;

namespace ShapesTests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        public void TestCircleArea()
        {
            // Arrange
            // Calculate the answers that I am looking for
            int expectedArea =(int)Math.Round((100 * Math.PI));
            int expectedPerimeter =(int)Math.Round((20 * Math.PI));

            // Act
            Circle circle = new Circle(10, System.ConsoleColor.Blue, true);

            // Assert that the area is correct
            int actualArea = circle.Area;
            Assert.AreEqual(expectedArea, actualArea, "The area was calculated incorrectly.");

            // Assert that the area is correct
            int actualPerimeter = circle.Perimeter;
            Assert.AreEqual(expectedPerimeter, actualPerimeter, "The perimeter was calculated incorrectly.");

        }
    }
}
