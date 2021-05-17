using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace iStock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MaterialW : MetroWindow
    {
        private Material m;
        public MaterialW(Material m = null)
        {
            InitializeComponent();
            if (m == null)
            {
                m = new Material();
            }

            this.m = m;
            this.DataContext = m;
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
            //using (var db = new Model1())
            //{
            //    if (cbAll.IsChecked != true)
            //    {
            //        LD = db.Departments.Where(tt => tt.Status == "Active").ToList();
            //    }
            //    else
            //    {
            //        LD = db.Departments.ToList();
            //    }
            //}
            //GBDepers.Header = LD.Count.ToString();
            //DGDepers.ItemsSource = LD;
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {
                if (m.MatId == 0)
                {
                    Create();
                }
                else
                {
                    UPdate();
                }
            }
        }

        private bool Check()
        {
            return true;
        }

        private void Create()
        {

        }

        private void UPdate()
        {

        }

        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.Owner.Activate();
            return;
        }
    }
}
