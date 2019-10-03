using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Exercises.Tests
{
    [TestClass]
    public class WordCountTests

    {
        [TestMethod]
        public void GetCount()
        {

            // Arrange
            WordCount ex = new WordCount();

            // Act
            Dictionary<string, int> actualResult = ex.GetCount(new string[] {});

            // Assert
            CollectionAssert.AreEqual(new string[] {}, actualResult);
        }
    }
}