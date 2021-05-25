using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace iStock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TransactionsW : MetroWindow
    {
        private List<Transaction> LT;
        public TransactionsW(Material m = null)
        {
            InitializeComponent();
        }

        private void MetroWindow_ContentRendered(object sender, EventArgs e)
        {
            GO();
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            this.Close();
            this.Owner.Activate();
            return;
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
            List<Material> lm = null;
            using (var db = new Model1())
            {
                 lm = db.Materials.ToList();
                if (cbAll.IsChecked != true)
                {
                    LT = db.Transactions.Where(tt => tt.Status == "פעיל").ToList();
                }
                else
                {
                    LT = db.Transactions.ToList();
                }
            }

            LT.ForEach(
                       tt => tt.Name1 = lm.FirstOrDefault(x => x.MatId == tt.MatId) != null ?
                                        lm.FirstOrDefault(x => x.MatId == tt.MatId).Name1 : ""
            );

            LT = LT.OrderBy(x => x.Date1).ThenBy(y=>y.TrnId).ToList();
            GBTranzs.Header = LT.Count.ToString();
            DGTranzs.ItemsSource = LT;
        }

        private void TbSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string filter = tbSearch.Text;
            ICollectionView icv = CollectionViewSource.GetDefaultView(DGTranzs.ItemsSource);

            if (filter == "")
            {
                icv.Filter = null;
            }
            else
            {
                icv.Filter = trnzs =>
                {
                    Transaction t = trnzs as Transaction;
                    return (
                            t.MatId.ToString().Contains(filter) ||
                            t.Name1.ToLower().Contains(filter.ToLower()) ||
                            t.Direction.ToLower().Contains(filter.ToLower())
                           );
                };
            }
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
            Transaction t = null;
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
            Transaction t = null;
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

        private void BAddNew_Click(object sender, RoutedEventArgs e)
        {
            Transaction t = null;
            if (DGTranzs.SelectedItem == null)
            {
                return;
            }

            t = DGTranzs.SelectedItem as Transaction;
            if (t == null)
            {
                return;
            }
            Material m = null;
            using (var db = new Model1())
            {
                m = db.Materials.FirstOrDefault(tt => tt.MatId == t.MatId);
            }
            TransactionW tw = new TransactionW(m);
            tw.Owner = this;
            tw.ShowDialog();
            GO();
        }
    }
}
