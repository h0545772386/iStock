using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace iStock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
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

        private void TbSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void cbAll_Checked(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void cbAll_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        private void OnHyperlinkClick(object sender, RoutedEventArgs e)
        {

        }

        private void DGMaterials_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void BExitk_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
