using System.Windows;
using static System.Net.Mime.MediaTypeNames;

enum HashTyp
{
    Null,
    SHA1,
    SHA256,
    SHA512,
    MD5
}

namespace HashCracker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SimpleBruteForce_Click(object sender, RoutedEventArgs e)
        {
            string input = TBxInput.Text;
            GetHashType getHashType = new GetHashType();
            HashTyp hashtyp = getHashType.execute(input);

            string result = "";

            BruteForceSimple bruteForceSimple = new BruteForceSimple(input);

            switch (hashtyp)
            {
                case HashTyp.SHA1:
                    TBEncodedHash.Text = "Result: " + bruteForceSimple.SHA1();
                    result = "SHA1";
                    break;
                default:
                    result = "Not recognizable";
                    break;
            }
            TBWhichHash.Text = "Hash: " + result;
        }

        private void DictionaryBruteForce_Click(object sender, RoutedEventArgs e)
        {
            string input = TBxInput.Text;

            GetHashType getHashType = new GetHashType();
            HashTyp hashtyp = getHashType.execute(input);

            string result = "";

            BruteForceDictionary bruteForceDictionary = new BruteForceDictionary();

            switch (hashtyp)
            {
                case HashTyp.SHA1:
                    TBEncodedHash.Text = "Result: " + bruteForceDictionary.SHA1(input);
                    result = "SHA1";
                    break;
                case HashTyp.SHA256:
                    TBEncodedHash.Text = "Result: " + bruteForceDictionary.SHA256(input);
                    result = "SHA256";
                    break;
                case HashTyp.SHA512:
                    TBEncodedHash.Text = "Result: " + bruteForceDictionary.SHA512(input);
                    result = "SHA512";
                    break;
                case HashTyp.MD5:
                    TBEncodedHash.Text = "Result: " + bruteForceDictionary.MD5(input);
                    result = "MD5";
                    break;
                default:
                    result = "Not recognizable";
                    break;
            }
            TBWhichHash.Text = "Hash: " + result;
        }
    }
}