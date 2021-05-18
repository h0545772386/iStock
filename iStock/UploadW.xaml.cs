using MahApps.Metro.Controls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace iStock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UploadW : MetroWindow
    {
        private Material M;
        private List<Material> LM;
        public UploadW()
        {
            InitializeComponent();
        }

        private void MetroWindow_ContentRendered(object sender, System.EventArgs e)
        {

        }

        private void bBrowse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbAll_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cbAll_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void DGSranzs_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void OnHyperlinkClick(object sender, RoutedEventArgs e)
        {

        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.Owner.Activate();
            return;
        }

        //private void MetroWindow_ContentRendered(object sender, EventArgs e)
        //{
        //    GO();
        //}
        //private void GO()
        //{
        //    var lw = this.Dispatcher.BeginInvoke(new Action(() =>
        //    {
        //        GetRecords();
        //    }));
        //}

        //private void GetRecords()
        //{
        //    using (var db = new Model1())
        //    {
        //        if (cbAll.IsChecked != true)
        //        {
        //            LM = db.Materials.Where(tt => tt.Status == "פעיל").ToList();
        //        }
        //        else
        //        {
        //            LM = db.Materials.ToList();
        //        }
        //    }
        //    GBMaterials.Header = LM.Count.ToString();
        //    DGMaterials.ItemsSource = LM;
        //}

        //private void TbSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        //{

        //}

        //private void cbAll_Checked(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    GO();
        //}

        //private void cbAll_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    GO();
        //}
        //private void OnHyperlinkClick(object sender, RoutedEventArgs e)
        //{
        //    if (DGMaterials.SelectedItem == null)
        //    {
        //        return;
        //    }

        //    M = DGMaterials.SelectedItem as Material;
        //    if (M == null)
        //    {
        //        return;
        //    }
        //    MaterialW mw = new MaterialW(M);
        //    mw.Owner = this;
        //    mw.ShowDialog();

        //    GO();
        //}

        //private void DGMaterials_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    if (DGMaterials.SelectedItem == null)
        //    {
        //        return;
        //    }

        //    M = DGMaterials.SelectedItem as Material;
        //    if (M == null)
        //    {
        //        return;
        //    }
        //}

        //private void BExitk_Click(object sender, System.Windows.RoutedEventArgs e)
        //{

        //}


        //private void BAddMaterial_Click(object sender, RoutedEventArgs e)
        //{
        //    MaterialW mw = new MaterialW();
        //    mw.Owner = this;
        //    mw.ShowDialog();

        //    GO();
        //}

        //private void BLoadCSV_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //    this.Owner.Activate();
        //    return;
        //}
    }
}
