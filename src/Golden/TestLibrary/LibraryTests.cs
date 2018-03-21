using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;

namespace TestLibrary
{
    [TestClass]
    public class LibraryTests
    {
        [TestMethod]
        public void ThingGetsOjbectValFromNumber()
        {
            Assert.AreEqual(42, new Thing().Get(42));
        }
    }
}
