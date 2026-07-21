using System.IO;
namespace HashCracker
{
    class BruteForce
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

        public string SHA1(string input)
        {
            HashStringConvert Converter = new HashStringConvert();
            List<string> stringList = GetBruteForceFileinStringList();

            foreach (string line in stringList)
            {
                string hashLine = Converter.StringToHashSHA1(line);
                if (hashLine != input)
                {
                    continue;
                }
                else
                {
                    return line;
                }
            }
            return "String not found in BruteForce";
        }

        public string SHA256(string input)
        {
            HashStringConvert Converter = new HashStringConvert();
            List<string> stringList = GetBruteForceFileinStringList();

            foreach (string line in stringList)
            {
                string hashLine = Converter.StringToHashSHA256(line);
                if (hashLine != input)
                {
                    continue;
                }
                else
                {
                    return line;
                }
            }
            return "String not found in BruteForce";
        }
        public string SHA512(string input)
        {
            HashStringConvert Converter = new HashStringConvert();
            List<string> stringList = GetBruteForceFileinStringList();

            foreach (string line in stringList)
            {
                string hashLine = Converter.StringToHashSHA512(line);
                if (hashLine != input)
                {
                    continue;
                }
                else
                {
                    return line;
                }
            }
            return "String not found in BruteForce";
        }

        public string MD5(string input)
        {
            HashStringConvert Converter = new HashStringConvert();
            List<string> stringList = GetBruteForceFileinStringList();

            foreach (string line in stringList)
            {
                string hashLine = Converter.StringToHashMD5(line);
                if (hashLine != input)
                {
                    continue;
                }
                else
                {
                    return line;
                }
            }
            return "String not found in BruteForce";
        }
    }
}