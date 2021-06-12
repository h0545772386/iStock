using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;

namespace iStock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow1 : MetroWindow
    {
        private Material M;
        private List<Material> LM;
        private readonly CancellationTokenSource tokenSource;
        public MainWindow1(List<Material> LM)
        {
            InitializeComponent();
            this.LM = LM;
        }

        private void MetroWindow_ContentRendered(object sender, EventArgs e)
        {
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
            
        }

        private void cbAll_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            
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
        }

        private void BTranzs_Click(object sender, RoutedEventArgs e)
        {
            TransactionsW tw = new TransactionsW();
            tw.Owner = this;
            tw.ShowDialog();
            
        }

        private void BLoadCSV_Click(object sender, RoutedEventArgs e)
        {
            UploadW uw = new UploadW();
            uw.Owner = this;
            uw.ShowDialog();
           
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
           
        }

        private void bReports_Click(object sender, RoutedEventArgs e)
        {
           
                       
        }

        
    }
}
