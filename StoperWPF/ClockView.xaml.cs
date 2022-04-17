using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using Time_TimePeriod;

namespace Stoper_Zegar_WPF
{
    /// <summary>
    /// Interaction logic for ClockView.xaml
    /// </summary>
    public partial class ClockView : Page
    {
        private static TimePeriod sekunda = new TimePeriod(0, 0, 1);
        private Time czas = new Time((byte)DateTime.Now.Hour, (byte)DateTime.Now.Minute, (byte)DateTime.Now.Second);

        public ClockView()
        {
            InitializeComponent();
            init();
        }

        private async void init()
        {
            godzinaLabel.Content = $"{czas.Hours:D2}";
            minutaLabel.Content = $"{czas.Minutes:D2}";
            sekundaLabel.Content = $"{czas.Seconds:D2}";
            while (true)
            {
                await Task.Delay(1000);
                czas = czas + sekunda;
                godzinaLabel.Content = $"{czas.Hours:D2}";
                minutaLabel.Content = $"{czas.Minutes:D2}";
                sekundaLabel.Content = $"{czas.Seconds:D2}";
            }
        }
    }
}