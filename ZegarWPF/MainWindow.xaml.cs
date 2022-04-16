using System;
using System.Threading.Tasks;
using System.Windows;
using Time_TimePeriod;

namespace Zegar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static TimePeriod sekunda = new TimePeriod(0, 0, 1);
        private Time czas = new Time((byte)DateTime.Now.Hour, (byte)DateTime.Now.Minute, (byte)DateTime.Now.Second);

        public MainWindow()
        {
            InitializeComponent();
            godzinaLabel.Content = czas;
        }

        private async void Grid_Initialized(object sender, EventArgs e)
        {
            while (true)
            {
                await Task.Delay(1000);
                czas = czas + sekunda;
                godzinaLabel.Content = czas;
            }
        }
    }
}