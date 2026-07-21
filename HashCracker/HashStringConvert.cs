using System.Security.Cryptography;

namespace HashCracker
{
    class HashStringConvert
    {
        public string StringToHash(string password)
        {
            SHA256 sha = SHA256.Create();

            byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha.ComputeHash(textBytes);

            string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
            return hash.ToLower();
        }
    }
}
