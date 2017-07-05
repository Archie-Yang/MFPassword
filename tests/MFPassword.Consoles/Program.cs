using System;

namespace MFPassword.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyA = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            var keyB = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            var mfPwd = MifarePassword.Generate(keyA, keyB);
            Console.WriteLine($"MIFARE key A = {BitConverter.ToString(keyA)}");
            Console.WriteLine($"MIFARE key B = {BitConverter.ToString(keyB)}");
            Console.WriteLine($"MIFARE password = {BitConverter.ToString(mfPwd)}");
            Console.WriteLine();
            keyA = new byte[] { 0xA0, 0xA1, 0xA2, 0xA3, 0xA4, 0xA5 };
            keyB = new byte[] { 0xB0, 0xB1, 0xB2, 0xB3, 0xB4, 0xB5 };
            mfPwd = MifarePassword.Generate(keyA, keyB);
            Console.WriteLine($"MIFARE key A = {BitConverter.ToString(keyA)}");
            Console.WriteLine($"MIFARE key B = {BitConverter.ToString(keyB)}");
            Console.WriteLine($"MIFARE password = {BitConverter.ToString(mfPwd)}");
        }
    }
}
