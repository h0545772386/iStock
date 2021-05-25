using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace iStock
{
    public class Fonts : INotifyPropertyChanged
    {
        private double gridFont { get; set; }
        private double windowFont { get; set; }

        public Fonts()
        {
            gridFont = Properties.Settings.Default.GridFont;
            windowFont = Properties.Settings.Default.WindowFont;
        }
        public double GridFont
        {
            get { return gridFont; }
            set
            {
                gridFont = value;
                OnPropertyChanged();
            }
        }
        public double WindowFont
        {
            get { return windowFont; }
            set
            {
                windowFont = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
