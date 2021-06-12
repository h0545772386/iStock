using MahApps.Metro.Controls;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace iStock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TransactionW : MetroWindow
    {
        private LUOM LUOMs;
        private Material m;
        private Transaction t;
        public TransactionW(Transaction t)
        {
            InitializeComponent();
            this.t = t;
            this.DataContext = t;
            dpDate1.SelectedDate = t.Date1.INT2Date();
        }

        public TransactionW(Material m)
        {
            InitializeComponent();
            this.m = m;
            t = new Transaction();
            t.Mode = "New";
            t.MatId = m.MatId;
            t.Name1 = m.Name1;
            this.DataContext = t;
            dpDate1.SelectedDate = DateTime.Now;
        }

        private void MetroWindow_ContentRendered(object sender, EventArgs e)
        {
            GO();
            LUOMs = new LUOM();
            cbUOM1.ItemsSource = LUOMs;
            if (t.Mode == "New")
            {
                cbInOut.SelectedIndex = 1;
                cbStatus.SelectedIndex = 0;
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
            using (var db = new Model1())
            {
                m = db.Materials.FirstOrDefault(tt => tt.MatId == t.MatId);
            }
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            if (dpDate1.SelectedDate.Value > DateTime.Today)
            {
                MSGW msgw = new MSGW();
                msgw.Owner = this;
                msgw.SetMessage("!תנועה עם תאריך עתידי");
                msgw.ShowDialog();
                return;
            }
            if (Check())
            {
                t.Date1 = dpDate1.SelectedDate.Value.DateToINT_YYYYMMDD();
                if (m.Date1 < t.Date1)
                {
                    m.Date1 = t.Date1;
                }

                if (t.Mode == "New")
                {
                    t.LoadNum = DB_Provider.GetLoadNum();
                    t.Batch1 = UTILS.GetBatch1(dpDate1.SelectedDate.Value);
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
            if (tbTrnQTY.Text == "")
            {
                MSGW msgw = new MSGW();
                msgw.Owner = this;
                msgw.SetMessage("חובה להכניס כמות");
                msgw.ShowDialog();
                return false;
            }
            if (cbUOM1.SelectedValue == null)
            {
                MSGW msgw = new MSGW();
                msgw.Owner = this;
                msgw.SetMessage("חובה להכניס יחידות מידה");
                msgw.ShowDialog();
                return false;
            }
            if (cbInOut.SelectedValue == null)
            {
                MSGW msgw = new MSGW();
                msgw.Owner = this;
                msgw.SetMessage("חובה להכניס הוצאת מאלי או הכנסה למלאי");
                msgw.ShowDialog();
                return false;
            }
            return true; //All is ok continue create or update
        }

        private void Create()
        {
            Dispatcher.BeginInvoke(new Action(() => { Create1(); }));
        }

        private void Create1()
        {
            using (var db = new Model1())
            {
                db.Transactions.Add(t);
                db.SaveChanges();
                if (m.UOM2 == null || m.UOM2 == "")
                {
                    m.UOM2 = m.UOM1;
                }

                db.Materials.AddOrUpdate(m);
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
                db.Transactions.AddOrUpdate(t);
                db.SaveChanges();
            }
        }

        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.Owner.Activate();
            return;
        }

        private void TbTrnQTY_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            UTILS.Decimal_PreviewTextInput(sender, e);
        }

        private void BPrev_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BNext_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
