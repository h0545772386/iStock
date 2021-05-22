using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Documents;

namespace iStock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BussyW : MetroWindow
    {
        public string Res { get; set; }
        public BussyW()
        {
            InitializeComponent();
        }

        private void MetroWindow_ContentRendered(object sender, System.EventArgs e)
        {

        }

        private void BOK_Click(object sender, RoutedEventArgs e)
        {
            Do1();
            this.Close();
            this.Owner.Activate();
            return;
        }

        private void Do1()
        {
            Res = "Ok";
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            Res = "";
            this.Close();
            this.Owner.Activate();
            return;
        }
    }
}
