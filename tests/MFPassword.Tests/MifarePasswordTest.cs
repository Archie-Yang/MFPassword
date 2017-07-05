using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MFPassword.Tests
{
    [TestClass]
    public class MifarePasswordTest
    {
        /// <summary>
        /// Test for MIFARE key A = A0A1A2A3A4A5, MIFARE key B = B0B1B2B3B4B5.
        /// </summary>
        [TestMethod]
        public void TestKeysA0A1A2A3A4A5B0B1B2B3B4B5()
        {
            var keyA = new byte[] { 0xA0, 0xA1, 0xA2, 0xA3, 0xA4, 0xA5 };
            var keyB = new byte[] { 0xB0, 0xB1, 0xB2, 0xB3, 0xB4, 0xB5 };
            var mfPwd = MifarePassword.Generate(keyA, keyB);
            CollectionAssert.AreEqual(mfPwd, new byte[] { 0x8C, 0x7F, 0x46, 0xD7, 0x6C, 0xE0, 0x12, 0x66 });
        }

        /// <summary>
        /// Test for MIFARE key A = FFFFFFFFFFFF, MIFARE key B = FFFFFFFFFFFF.
        /// </summary>
        [TestMethod]
        public void TestKeysFFFFFFFFFFFFFFFFFFFFFFFF()
        {
            var keyAB = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            var mfPwd = MifarePassword.Generate(keyAB, keyAB);
            CollectionAssert.AreEqual(mfPwd, new byte[] { 0x0B, 0x54, 0x57, 0x07, 0x45, 0xFE, 0x3A, 0xE7 });
        }
    }
}
