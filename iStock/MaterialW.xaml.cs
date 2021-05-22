using MahApps.Metro.Controls;
using System;
using System.Data.Entity.Migrations;
using System.Windows;

namespace iStock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MaterialW : MetroWindow
    {
        private Material m;
        private LUOM LUOMs;
        public MaterialW(Material m = null)
        {
            InitializeComponent();
            LUOMs = new LUOM();
            if (m == null)
            {
                m = new Material();
                m.Mode = "New";
            }

            this.m = m;
            this.DataContext = m;
            cbUOM1.ItemsSource = LUOMs;
            cbUOM2.ItemsSource = LUOMs;
        }

        private void MetroWindow_ContentRendered(object sender, EventArgs e)
        {
            GO();
            if (m.Mode == "New")
            {
                cbStatus.SelectedIndex = 0;
                cbUOM1.SelectedIndex = 0;
                cbUOM2.SelectedIndex = 0;
            }
            else
            {
                tbMatId.IsReadOnly = true;
            }
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
                if (m.Mode == "New")
                {
                    Create();
                }
                else
                {
                    UpDdate();
                }
                this.Close();
                this.Owner.Activate();
                return;
            }
        }

        private bool Check()
        {
            bool check_result = true; //All is ok continue create or update
            if (cbUOM1.SelectedValue == null)
            {
                MSGW msgw = new MSGW();
                msgw.Owner = this;
                msgw.SetMessage("חובה להכניס יחידת מידה בסיסית לחומר");
                msgw.ShowDialog();
                return false;
            }

            if (cbUOM2.SelectedValue == null)
            {
                cbUOM2.SelectedValue = cbUOM1.SelectedValue;
            }
            if (cbUOM2.SelectedValue.ToString() == "")
            {
                cbUOM2.SelectedValue = cbUOM1.SelectedValue;
            }


            if (m.Mode == "New")  // new material
            {
                if (tbMatId.Text == "" || tbMatId.Text == "0")
                {
                    MSGW msgw = new MSGW();
                    msgw.Owner = this;
                    msgw.SetMessage("חובה להכניס מזהה חומר");
                    msgw.ShowDialog();
                    return false;
                }

                if (DB_Provider.MatIdAlreadyExist(m.MatId))
                {
                    MSGW msgw = new MSGW();
                    msgw.Owner = this;
                    msgw.SetMessage("חמזהה חומר כבר קיים");
                    msgw.ShowDialog();
                    return false;
                }
            }
            else   // update exists material
            {

            }

            if (tbMatName.Text == "")
            {
                MSGW msgw = new MSGW();
                msgw.Owner = this;
                msgw.SetMessage("חובה להכניס תאור חומר");
                msgw.ShowDialog();
                return false;
            }

            if (m.MinQTY > m.MaxQTY)
            {
                MSGW msgw = new MSGW();
                msgw.Owner = this;
                msgw.SetMessage("כמות חומר מינימלית גדולה מכמות מקסימלית");
                msgw.ShowDialog();
                return false;
            }
            return check_result;
        }

        private void Create()
        {
            Dispatcher.BeginInvoke(new Action(() => { Create1(); }));
        }

        private void Create1()
        {
            using (var db = new Model1())
            {
                db.Materials.Add(m);
                db.SaveChanges();
            }
        }

        private void UpDdate()
        {
            Dispatcher.BeginInvoke(new Action(() => { UpDdate1(); }));
        }
        private void UpDdate1()
        {
            using (var db = new Model1())
            {
                if (m.UOM2 == null || m.UOM2 == "")
                {
                    m.UOM2 = m.UOM1;
                }
                db.Materials.AddOrUpdate(m);
                db.SaveChanges();
            }
        }

        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.Owner.Activate();
            return;
        }

        private void CbUOM1_DropDownClosed(object sender, EventArgs e)
        {
            cbUOM2.SelectedItem = cbUOM1.SelectedItem;
        }
    }
}
