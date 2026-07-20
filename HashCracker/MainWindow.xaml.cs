using System.Windows;
using static HashCracker.HashStringConvert;

namespace HashCracker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HashStringConvert HSC = new HashStringConvert();
            TBEncodedHash.Text = HSC.StringToHash(TBxInput.Text);
        }
    }
}