using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Input;

namespace HashCracker
{
    class GetHashType
    {
        public HashTyp execute(string input)
        {
            // Bekomme Anzahl der Character des Strings
            int anzahlCharacter = 0;
            foreach (char c in input)
            {
                anzahlCharacter++;
            }

            // Hashtyp: SHA1
            if (anzahlCharacter == 40)
            {
                return HashTyp.SHA1;
            }
            // Hashtyp: SHA256
            else if (anzahlCharacter == 64)
            {
                return HashTyp.SHA256;
            }
            // Hashtyp: MD5
            else if (anzahlCharacter == 96)
            {
                return HashTyp.SHA384;
            }
            // Hashtyp: SHA512
            else if (anzahlCharacter == 128)
            {
                return HashTyp.SHA512;
            }
            // Hashtyp: MD5
            else if (anzahlCharacter == 32)
            {
                return HashTyp.MD5;
            }

            return HashTyp.Null;
        }
    }
}