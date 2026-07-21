using System.Windows;

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
            BruteForce bruteForce = new BruteForce();
            TBEncodedHash.Text = bruteForce.execute(TBxInput.Text);
        }
    }
}