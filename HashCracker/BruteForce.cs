using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HashCracker
{
    class BruteForce
    {
        public List<string> ReadBruteForceFile()
        {
            List<string> stringList = new List<string> { };
            var lines = File.ReadLines(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Source", "10k-most-common.txt")));

            foreach(var line in lines)
            {
                stringList.Add(line);
            }
            return stringList;
        }
    }
}
