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
    public partial class MainWindow : MetroWindow
    {
        private Material M;
        private List<Material> LM;
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
            List<Transaction> LT = null;
            using (var db = new Model1())
            {
                if (cbAll.IsChecked != true)
                {
                    LM = db.Materials.Where(tt => tt.Status == "פעיל").ToList();
                    LT = db.Transactions.Where(tt => tt.Status == "פעיל").ToList();
                }
                else
                {
                    LM = db.Materials.ToList();
                }
            }
            LM = LM.OrderBy(x => x.Name1).ToList();
            LM.ForEach(
                tt => tt.TotalQTY = LT.Where(x => x.MatId == tt.MatId && x.Direction == "IN").Sum(y => y.TrnQTY) -
                                    LT.Where(x => x.MatId == tt.MatId && x.Direction == "OUT").Sum(y => y.TrnQTY)
                );
            GBMaterials.Header = LM.Count.ToString();
            DGMaterials.ItemsSource = LM;
        }

        private void TbSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string filter = tbSearch.Text;
            ICollectionView icv = CollectionViewSource.GetDefaultView(DGMaterials.ItemsSource);

            if (filter == "")
            {
                icv.Filter = null;
            }
            else
            {
                icv.Filter = mats =>
                {
                    Material m = mats as Material;
                    return (
                            m.MatId.ToString().Contains(filter) ||
                            m.Name1.ToLower().Contains(filter.ToLower()) ||
                            m.BrCode1.ToLower().Contains(filter.ToLower())
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
            if (DGMaterials.SelectedItem == null)
            {
                return;
            }

            M = DGMaterials.SelectedItem as Material;
            if (M == null)
            {
                return;
            }
            MaterialW mw = new MaterialW(M);
            mw.Owner = this;
            mw.ShowDialog();

            GO();
        }

        private void DGMaterials_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (DGMaterials.SelectedItem == null)
            {
                return;
            }

            M = DGMaterials.SelectedItem as Material;
            if (M == null)
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

        private void BTranzs_Click(object sender, RoutedEventArgs e)
        {
            TransactionsW tw = new TransactionsW();
            tw.Owner = this;
            tw.ShowDialog();
            GO();
        }

        private void BLoadCSV_Click(object sender, RoutedEventArgs e)
        {
            UploadW uw = new UploadW();
            uw.Owner = this;
            uw.ShowDialog();
            GO();
        }

        private void BAddTranz_Click(object sender, RoutedEventArgs e)
        {
            Material m = null;
            if (DGMaterials.SelectedItem == null)
            {
                return;
            }

            m = DGMaterials.SelectedItem as Material;
            if (m == null)
            {
                return;
            }
            TransactionW tw = new TransactionW(m);
            tw.Owner = this;
            tw.ShowDialog();
            GO();
        }
    }
}
