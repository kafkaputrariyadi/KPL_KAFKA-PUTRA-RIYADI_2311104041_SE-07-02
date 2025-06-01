using Microsoft.VisualStudio.TestTools.UnitTesting;
using JurnalModul12_2311104041;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPangkatNormal()
        {
            Assert.AreEqual(8, Helper.CariNilaiPangkat(2, 3));
        }

        [TestMethod]
        public void TestPangkatZero()
        {
            Assert.AreEqual(1, Helper.CariNilaiPangkat(0, 0));
        }

        [TestMethod]
        public void TestPangkatNegatif()
        {
            Assert.AreEqual(-1, Helper.CariNilaiPangkat(2, -3));
        }

        [TestMethod]
        public void TestInputBesar()
        {
            Assert.AreEqual(-2, Helper.CariNilaiPangkat(101, 5));
            Assert.AreEqual(-2, Helper.CariNilaiPangkat(3, 11));
        }

        [TestMethod]
        public void TestOverflow()
        {
            Assert.AreEqual(-3, Helper.CariNilaiPangkat(100, 10));
        }
    }
}