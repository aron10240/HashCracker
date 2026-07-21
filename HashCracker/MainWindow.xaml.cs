using System.Diagnostics;
using System.IO;
using System.Windows;
using static HashCracker.BruteForce;
using static HashCracker.HashStringConvert;

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
            TBEncodedHash.Text = bruteForce.ReadBruteForceFile().Count.ToString();
        }
    }
}