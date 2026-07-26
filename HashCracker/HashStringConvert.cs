using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

namespace HashCracker
{
    class HashStringConvert
    {
        public string StringToHashSHA1(string password)
        {
            SHA1 sha = SHA1.Create();

            byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha.ComputeHash(textBytes);

            string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
            return hash.ToLower();
        }

        public string StringToHashSHA256(string password)
        {
            SHA256 sha = SHA256.Create();

            byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha.ComputeHash(textBytes);

            string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
            return hash.ToLower();
        }

        public string StringToHashSHA384(string password)
        {
            SHA384 sha = SHA384.Create();

            byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha.ComputeHash(textBytes);

            string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
            return hash.ToLower();
        }

        public string StringToHashSHA512(string password)
        {
            SHA512 sha = SHA512.Create();

            byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha.ComputeHash(textBytes);

            string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
            return hash.ToLower();
        }
        public string StringToHashMD5(string password)
        {
            MD5 sha = MD5.Create();

            byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha.ComputeHash(textBytes);

            string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
            return hash.ToLower();
        }
    }
}