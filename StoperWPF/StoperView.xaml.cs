using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Time_TimePeriod;

namespace Stoper_Zegar_WPF
{
    /// <summary>
    /// Interaction logic for StoperView.xaml
    /// </summary>
    public partial class StoperView : Page
    {
        private static TimePeriod milisekunda = new TimePeriod(0, 0, 1);
        private TimePeriod stoperek = new TimePeriod(0, 0, 0);
        private bool isClicked;

        public StoperView()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            isClicked = false;
            stoperek = new TimePeriod(0, 0, 0);
            minutaLabel.Content = "00";
            sekundaLabel.Content = "00";
            miliSekundaLabel.Content = "00";
            btnStartStop.Content = "START";
        }

        #region LABEL

        private void minutaLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            Color backColor = Color.FromRgb(75, 159, 234);
            //Color backColor = Color.FromRgb(30, 136, 229);
            SolidColorBrush brush = new SolidColorBrush(backColor);
            minutaLabel.Foreground = brush;
        }

        private void minutaLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            Color backColor = Color.FromRgb(255, 255, 255);
            SolidColorBrush brush = new SolidColorBrush(backColor);
            minutaLabel.Foreground = brush;
        }

        private void sekundaLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            Color backColor = Color.FromRgb(75, 159, 234);
            //Color backColor = Color.FromRgb(30, 136, 229);
            SolidColorBrush brush = new SolidColorBrush(backColor);
            sekundaLabel.Foreground = brush;
        }

        private void sekundaLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            Color backColor = Color.FromRgb(255, 255, 255);
            SolidColorBrush brush = new SolidColorBrush(backColor);
            sekundaLabel.Foreground = brush;
        }

        private void miliSekundaLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            Color backColor = Color.FromRgb(75, 159, 234);
            //Color backColor = Color.FromRgb(30, 136, 229);
            SolidColorBrush brush = new SolidColorBrush(backColor);
            miliSekundaLabel.Foreground = brush;
        }

        private void miliSekundaLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            Color backColor = Color.FromRgb(255, 255, 255);
            SolidColorBrush brush = new SolidColorBrush(backColor);
            miliSekundaLabel.Foreground = brush;
        }

        #endregion LABEL

        private void btnReset_MouseDown(object sender, MouseButtonEventArgs e)
        {
            init();
        }

        private void btnReset_MouseEnter(object sender, MouseEventArgs e)
        {
            Color backColor = Color.FromRgb(2, 108, 160);
            SolidColorBrush brush = new SolidColorBrush(backColor);
            borderBtnReset.Background = brush;
        }

        private void btnReset_MouseLeave(object sender, MouseEventArgs e)
        {
            Color backColor = Color.FromRgb(30, 136, 229);
            SolidColorBrush brush = new SolidColorBrush(backColor);
            borderBtnReset.Background = brush;
        }

        private async void btnStartStop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isClicked)
            {
                btnStartStop.Content = "START";
                isClicked = false;
            }
            else
            {
                btnStartStop.Content = "STOP";
                isClicked = true;
            }
            while (isClicked)
            {
                stoperek = stoperek + milisekunda;
                minutaLabel.Content = $"{stoperek.Hours:D2}";
                sekundaLabel.Content = $"{stoperek.Minutes:D2}";
                miliSekundaLabel.Content = $"{stoperek.Seconds:D2}";
                await Task.Delay(10);
            }
        }

        private void btnStartStop_MouseEnter(object sender, MouseEventArgs e)
        {
            Color backColor = Color.FromRgb(2, 108, 160);
            SolidColorBrush brush = new SolidColorBrush(backColor);
            borderBtnStartStop.Background = brush;
        }

        private void btnStartStop_MouseLeave(object sender, MouseEventArgs e)
        {
            Color backColor = Color.FromRgb(30, 136, 229);
            SolidColorBrush brush = new SolidColorBrush(backColor);

            borderBtnStartStop.Background = brush;
        }
    }
}