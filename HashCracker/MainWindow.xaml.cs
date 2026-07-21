using System.Windows;

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

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            //HashStringConvert Converter = new HashStringConvert();
            //TBEncodedHash.Text = Converter.StringToHashSHA256(TBxInput.Text);
        }

        private void BruteForce_Click(object sender, RoutedEventArgs e)
        {
            GetTypOfHash(TBxInput.Text);
        }

        private void GetTypOfHash(string input)
        {
            GetHashType getHashType = new GetHashType();

            HashTyp hashtyp = getHashType.execute(input);
            string result = "";
            BruteForce bruteForce = new BruteForce();

            if (hashtyp == HashTyp.SHA1)
            {
                TBEncodedHash.Text = "Result: " + bruteForce.SHA1(input);
                result = "SHA1";
            }
            else if (hashtyp == HashTyp.SHA256)
            {
                TBEncodedHash.Text = "Result: " + bruteForce.SHA256(input);
                result = "SHA256";
            }
            else if (hashtyp == HashTyp.SHA512)
            {
                TBEncodedHash.Text = "Result: " + bruteForce.SHA512(input);
                result = "SHA512";
            }
            else if (hashtyp == HashTyp.MD5)
            {
                TBEncodedHash.Text = "Result: " + bruteForce.MD5(input);
                result = "MD5";
            }
            else if (hashtyp == HashTyp.Null)
            {
                result = "Not recognizable";
            }
            TBWhichHash.Text = "Hash: " + result;
        }
    }
}