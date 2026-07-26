using System.Windows;
using static System.Net.Mime.MediaTypeNames;

enum HashTyp
{
    Null,
    SHA1,
    SHA256,
    SHA384,
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

            BruteForceSimple bruteForceSimple = new BruteForceSimple(input, hashtyp);

            TBWhichHash.Text = "Hash: " + hashtyp;
            TBEncodedHash.Text = "Result: " + bruteForceSimple.BruteForce();
        }

        private void DictionaryBruteForce_Click(object sender, RoutedEventArgs e)
        {
            string input = TBxInput.Text;

            GetHashType getHashType = new GetHashType();
            HashTyp hashtyp = getHashType.execute(input);

            BruteForceDictionary bruteForceDictionary = new BruteForceDictionary();

            TBWhichHash.Text = "Hash: " + hashtyp;
            TBEncodedHash.Text = "Result: " + bruteForceDictionary.execute(input, hashtyp);
        }
    }
}