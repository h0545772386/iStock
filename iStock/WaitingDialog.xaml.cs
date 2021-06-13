using MahApps.Metro.Controls;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace iStock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WaitingDialog : Window
    {
        private readonly Action<WaitingDialog> action;
        private readonly CancellationTokenSource tokenSource;
        private readonly bool canBeCancelled;

        public WaitingDialog()
        {
            InitializeComponent();
        }
        public WaitingDialog(string title, string message, Action<WaitingDialog> action, bool canBeCancelled, Window owner = null, CancellationTokenSource tokenSource = default(CancellationTokenSource))
            : this()
        {
            this.action = action;
            this.canBeCancelled = canBeCancelled;
            this.tokenSource = tokenSource;
            Owner = owner;
            Title = title;
            lblDescription.Text = message;
            btnOk.Visibility = Visibility.Collapsed;
            btnCancel.Visibility = canBeCancelled ? Visibility.Visible : Visibility.Collapsed;
        }

        public void ToErrorDialog(string title, string message)
        {
            Title = title;
            lblDescription.Text = message;
            lblDescription.Foreground = new SolidColorBrush(Colors.Red);
            btnOk.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Collapsed;
            pbWaiting.Visibility = Visibility.Collapsed;
        }

        public void UpdateMessage(string text, Color color = default(Color))
        {
            lblDescription.Text = text;
            if (color != default(Color))
                lblDescription.Foreground = new SolidColorBrush(color);
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (action == null)
                return;
            await Task.Run(() => { action(this); }, tokenSource.Token);
        }

        private void OnOkClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            if (!canBeCancelled)
                return;

            UpdateMessage("Cancellation...");
            tokenSource.Cancel(true);
        }
    }
}
