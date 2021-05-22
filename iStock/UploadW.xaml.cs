using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        private void BCreateFile_Click(object sender, RoutedEventArgs e)
        {
            CSV();
        }

        private void CSV()
        {
            var lw = this.Dispatcher.BeginInvoke(new Action(() =>
            {
                CSV1();
            }));
        }

        private void CSV1()
        {
            Material m = null;
            using (var db = new Model1())
            {
                var mat_id = db.Materials.Max(id => id.MatId);
                m = db.Materials.FirstOrDefault(id => id.MatId == mat_id);
            }

            if (m == null)
            {
                m = new Material() { MatId = 164159, Name1 = "שם חומר", BrCode1 = "1111111", UOM1 = "יחידה", UOM2 = "יחידה", MinQTY = 0, MaxQTY = 0 };
            }

            var hdrs = "MatId,Name1,BrCode1,UOM1,UOM2,MinQTY,MaxQTY";
            var csv = m.ToString();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                var path_ = saveFileDialog.FileName + ".xls";
                using (StreamWriter sw = new StreamWriter(path_, false, Encoding.UTF8))
                {
                    sw.WriteLine(hdrs);
                    sw.WriteLine(csv);
                }
            }
        }
    }
}
