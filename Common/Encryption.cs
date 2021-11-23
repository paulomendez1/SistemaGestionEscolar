using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Encryption
    {
        private static readonly Random random = new Random();

        public static string RandomPW(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string EncriptarPW(string str)
        {
            _ = new byte[str.Length];
            byte[] encode = Encoding.UTF8.GetBytes(str);
            string strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }

        public static string DesencriptarPW(string str)
        {
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(str);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string decryptpwd = new string(decoded_char);
            return decryptpwd;
        }
    }
}
