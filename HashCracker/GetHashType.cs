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
            
            // Hashtyp: SHA256
            if(anzahlCharacter == 64)
            {
                return HashTyp.SHA256;
            }
            // Hashtyp: SHA1
            if (anzahlCharacter == 40)
            {
                return HashTyp.SHA1;
            }
            return HashTyp.Null;
        }
    }
}
