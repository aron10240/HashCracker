using System.IO;
namespace HashCracker
{
    class BruteForceDictionary
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

    class BruteForceSimple
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
            HashStringConvert Converter = new HashStringConvert();

            Func<string, string> hashFunktion = hashTyp switch
            {
                HashTyp.SHA1 => Converter.StringToHashSHA1,
                HashTyp.SHA512 => Converter.StringToHashSHA512,
                HashTyp.MD5 => Converter.StringToHashMD5,
                _ => throw new ArgumentException("Unbekannter Hash-Typ", nameof(hashTyp))
            };

            for (int length = 1; length <= 10; length++)
            {
                string result = TryAllCombinations(chars, length, "", hashFunktion, hash);
                if (!string.IsNullOrEmpty(result))
                    return result;
            }
            return "";
        }

        private string TryAllCombinations(string chars, int length, string current, Func<string, string> hashFunktion, string hash)
        {
            if (current.Length == length)
            {
                string hashLine = hashFunktion(current);
                return hashLine == hash ? current : "";
            }

            foreach (char c in chars)
            {
                string result = TryAllCombinations(chars, length, current + c, hashFunktion, hash);
                if (!string.IsNullOrEmpty(result))
                    return result;
            }
            return "";
        }
    }
}
