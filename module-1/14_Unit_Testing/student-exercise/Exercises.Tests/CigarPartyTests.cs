using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises
{
    [TestClass]
    public class CigarPartyTests
    {
        [TestMethod]
        public void HaveParty()
        {
            // Arrange
            CigarParty ex = new CigarParty();

            // Act
            bool actualResult = ex.HaveParty(30, false);

            // Assert
            Assert.AreEqual(false, actualResult);
        }
        [TestMethod]
        public void HaveParty2()
        {
            // Arrange
            CigarParty ex = new CigarParty();

            // Act
            bool actualResult = ex.HaveParty(50, false);

            // Assert
            Assert.AreEqual(true, actualResult);
        }
        [TestMethod]
        public void HaveParty3()
        {
            // Arrange
            CigarParty ex = new CigarParty();

            // Act
            bool actualResult = ex.HaveParty(70, true);

            // Assert
            Assert.AreEqual(true, actualResult);
        }
    }
}