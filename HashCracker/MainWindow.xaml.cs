using System.Windows;

enum HashTyp
{
    Null,
    SHA256,
    SHA1
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
            HashStringConvert Converter = new HashStringConvert();
            TBEncodedHash.Text = Converter.StringToHash(TBxInput.Text);
        }

        private void BruteForce_Click(object sender, RoutedEventArgs e)
        {
            TBWhichHash.Text = "Hash: " + GetTypOfHash(TBxInput.Text);

            BruteForce bruteForce = new BruteForce();
            TBEncodedHash.Text = "Result: " + bruteForce.execute(TBxInput.Text);
        }

        private string GetTypOfHash(string input)
        {
            GetHashType getHashType = new GetHashType();

            HashTyp hashtyp = getHashType.execute(input);
            string result = "";
            if (hashtyp == HashTyp.SHA256)
            {
                result = "SHA256";
            }
            else if (hashtyp == HashTyp.SHA1)
            {
                result = "SHA1";
            }
            else if (hashtyp == HashTyp.Null)
            {
                result = "Not recognizable";
            }
            return result;
        }
    }
}