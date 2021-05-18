using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace iStock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TransactionsW : MetroWindow
    {
        private Material m;
        private Transaction t;
        private List<Transaction> LT;
        public TransactionsW(Material m = null)
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
            using (var db = new Model1())
            {
                if (cbAll.IsChecked != true)
                {
                    LT = db.Transactions.Where(tt => tt.MatId == m.MatId && tt.Status == "פעיל").ToList();
                }
                else
                {
                    LT = db.Transactions.ToList();
                }
            }
            GBTranzs.Header = LT.Count.ToString();
            DGTranzs.ItemsSource = LT;
        }

        private void TbSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void cbAll_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            GO();
        }

        private void cbAll_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            GO();
        }
        private void OnHyperlinkClick(object sender, RoutedEventArgs e)
        {
            t = null;
            if (DGTranzs.SelectedItem == null)
            {
                return;
            }

            t = DGTranzs.SelectedItem as Transaction;
            if (t == null)
            {
                return;
            }
            TransactionW mw = new TransactionW(t);
            mw.Owner = this;
            mw.ShowDialog();

            GO();
        }



        private void DGTranzs_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            t = null;
            if (DGTranzs.SelectedItem == null)
            {
                return;
            }

            t = DGTranzs.SelectedItem as Transaction;
            if (t == null)
            {
                return;
            }
        }

        private void BExitk_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }


        private void BAddMaterial_Click(object sender, RoutedEventArgs e)
        {
            MaterialW mw = new MaterialW();
            mw.Owner = this;
            mw.ShowDialog();

            GO();
        }

        private void BLoadCSV_Click(object sender, RoutedEventArgs e)
        {
            UploadW uw = new UploadW();
            uw.Owner = this;
            uw.ShowDialog();

            GO();
        }
    }
}
