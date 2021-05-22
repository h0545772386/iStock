using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Documents;

namespace iStock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MSGW : MetroWindow
    {
        public string Res { get; set; }
        public MSGW()
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

        public void SetMessage(string msg)
        {
            FlowDocument fdoc = new FlowDocument();
            Paragraph para = new Paragraph();
            para.Inlines.Add(new Run(msg));
            fdoc.Blocks.Add(para);
            rtbText.Document = fdoc;
        }
        public void ShowCancelButton()
        {
            bCancel.Visibility = Visibility.Visible;
        }
    }
}
