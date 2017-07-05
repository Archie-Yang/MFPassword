using System;
using System.Security.Cryptography;

namespace MFPassword
{
    /// <summary>
    /// MIFARE password generation.
    /// </summary>
    public sealed class MifarePassword
    {
        /// <summary>
        /// Static IV/data for MIFARE password generation, 8-byte array with value zero.
        /// </summary>
        private static readonly byte[] _zeroData = new byte[8];

        /// <summary>
        /// Generates MIFARE password from specified MIFARE keys A and B.
        /// </summary>
        /// <param name="keyA">MIFARE key A(6-byte).</param>
        /// <param name="keyB">MIFARE key B(6-byte).</param>
        /// <returns>MIFARE password(8-byte).</returns>
        public static byte[] Generate(byte[] keyA, byte[] keyB)
        {
            if (!(keyA?.Length == 6 && keyB?.Length == 6))
            {
                throw new ArgumentException("MIFARE key A/B needs to be an 6-byte length byte array.");
            }
            using (var cipher = TripleDES.Create())
            {
                cipher.Mode = CipherMode.ECB;
                cipher.Padding = PaddingMode.None;
                var key = new byte[24];
                key[1] = key[17] = (byte)(keyA[0] >> 1 & 64 | keyA[1] >> 2 & 32 | keyA[2] >> 3 & 16 | keyA[3] >> 4 & 8 | keyA[4] >> 5 & 4 | keyA[5] >> 6 & 2);
                key[2] = key[18] = (byte)(keyA[5] << 1);
                key[3] = key[19] = (byte)(keyA[4] << 1);
                key[4] = key[20] = (byte)(keyA[3] << 1);
                key[5] = key[21] = (byte)(keyA[2] << 1);
                key[6] = key[22] = (byte)(keyA[1] << 1);
                key[7] = key[23] = (byte)(keyA[0] << 1);
                key[8] = (byte)(keyB[5] << 1);
                key[9] = (byte)(keyB[4] << 1);
                key[10] = (byte)(keyB[3] << 1);
                key[11] = (byte)(keyB[2] << 1);
                key[12] = (byte)(keyB[1] << 1);
                key[13] = (byte)(keyB[0] << 1);
                key[14] = (byte)(keyB[5] >> 1 & 64 | keyB[4] >> 2 & 32 | keyB[3] >> 3 & 16 | keyB[2] >> 4 & 8 | keyB[1] >> 5 & 4 | keyB[0] >> 6 & 2);
                using (var cryptor = cipher.CreateEncryptor(key, _zeroData))
                {
                    var mfPwd = cryptor.TransformFinalBlock(_zeroData, 0, 8);
                    Array.Reverse(mfPwd);
                    return mfPwd;
                }
            }
        }
    }
}
