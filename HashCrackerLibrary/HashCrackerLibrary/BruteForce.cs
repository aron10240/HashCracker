using System.IO;
using System.Security.Cryptography;
namespace HashCrackerLibrary
{
    public class BruteForceDictionary
    {
        private List<string> GetBruteForceFileinStringList()
        {
            List<string> stringList = new List<string> { };
            var lines = File.ReadLines(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Source", "10k-most-common.txt")));

            foreach (string line in lines)
            {
                stringList.Add(line);
            }
            return stringList;
        }

        public string execute(string input, HashTyp hashTyp)
        {
            HashStringConvert Converter = new HashStringConvert();
            List<string> stringList = GetBruteForceFileinStringList();

            Func<string, string> hashFunktion = Converter.StringToHashSHA1;
            switch(hashTyp)
            {

                case HashTyp.SHA1:
                    hashFunktion = Converter.StringToHashSHA1;
                        break;
                case HashTyp.SHA256:
                    hashFunktion = Converter.StringToHashSHA256;
                    break;
                case HashTyp.SHA384:
                    hashFunktion = Converter.StringToHashSHA384;
                    break;
                case HashTyp.SHA512:
                    hashFunktion = Converter.StringToHashSHA512;
                    break;
                case HashTyp.MD5:
                    hashFunktion = Converter.StringToHashMD5;
                    break;
                default: 
                    //
                    break;
            };

            foreach (string line in stringList)
            {
                if (hashFunktion(line) == input)
                {
                    return line;
                }
            }
            return "String not found in BruteForce";
        }
    }

    public class BruteForceSimple
    {
        private string hash;
        private HashTyp hashTyp;
        private string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
        public BruteForceSimple(string input, HashTyp hashTyp)
        {
            hash = input;
            this.hashTyp = hashTyp;
        }

        public string BruteForce()
        {
            byte[] targetHash;
            try
            {
                targetHash = Convert.FromHexString(hash);
            }
            catch (FormatException)
            {
                // Eingabe ist kein gültiger Hex-Hash
                return "";
            }

            Func<byte[], byte[]> hashFunktion = SHA1.HashData;
            switch (hashTyp)
            {
                case HashTyp.SHA1:
                    hashFunktion = SHA1.HashData;
                    break;
                case HashTyp.SHA256:
                    hashFunktion = SHA256.HashData;
                    break;
                case HashTyp.SHA384:
                    hashFunktion = SHA384.HashData;
                    break;
                case HashTyp.SHA512:
                    hashFunktion = SHA512.HashData;
                    break;
                case HashTyp.MD5:
                    hashFunktion = MD5.HashData;
                    break;
                default:
                    //
                    break;
            };

            byte[] charBytes = System.Text.Encoding.UTF8.GetBytes(chars);

            for (int length = 1; length <= 10; length++)
            {
                byte[] buffer = new byte[length];
                string result = TryAllCombinations(charBytes, buffer, 0, hashFunktion, targetHash);
                if (!string.IsNullOrEmpty(result))
                    return result;
            }
            return "";
        }

        private string TryAllCombinations(byte[] charBytes, byte[] buffer, int position, Func<byte[], byte[]> hashFunktion, byte[] targetHash)
        {
            if (position == buffer.Length)
            {
                byte[] hashBytes = hashFunktion(buffer);
                return targetHash.AsSpan().SequenceEqual(hashBytes)
                    ? System.Text.Encoding.UTF8.GetString(buffer)
                    : "";
            }

            foreach (byte b in charBytes)
            {
                buffer[position] = b;
                string result = TryAllCombinations(charBytes, buffer, position + 1, hashFunktion, targetHash);
                if (!string.IsNullOrEmpty(result))
                    return result;
            }
            return "";
        }
    }
}
