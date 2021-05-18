using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls;
using System.Windows.Controls;

namespace iStock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TransactionW : MetroWindow
    {
        private Material m;
        private Transaction t;
        public TransactionW(Transaction t = null)
        {
            InitializeComponent();
            if (t == null)
            {
                t = new Transaction();
            }

            this.t = t;
            this.DataContext = t;
        }

        private void MetroWindow_ContentRendered(object sender, EventArgs e)
        {
            GO();
        }
        private void GO()
        {
            var lw = this.Dispatcher.BeginInvoke(new Action(() =>
            {
                GetRecords();
            }));
        }

        private void GetRecords()
        {
            using (var db = new Model1())
            {
                m = db.Materials.FirstOrDefault(tt => tt.MatId == t.MatId);
            }
        }
    }
}
