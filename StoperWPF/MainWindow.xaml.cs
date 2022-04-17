using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Time_TimePeriod;

namespace StoperWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static TimePeriod milisekunda = new TimePeriod(0, 0, 1);
        private TimePeriod stoperek = new TimePeriod(0, 0, 0);
        private bool isClicked;
        private bool isVisibleNavbar = false;

        public MainWindow()
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

        private async void btnNavBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            btnNavbar.IsEnabled = false;
            if (!isVisibleNavbar)
            {
                imageNav.Source = new BitmapImage(new System.Uri("Image/menuClose.png", System.UriKind.Relative));
                isVisibleNavbar = true;
                for (int i = 60; i <= 180; i += 5)
                {
                    await Task.Delay(1);
                    stackNavbar.Width = i;
                }
                var uriSource = 
                btnNavbar.IsEnabled = true;
            }
            else
            {
                imageNav.Source = new BitmapImage(new System.Uri("Image/menu.png", System.UriKind.Relative));
                isVisibleNavbar = false;
                for (int i = 180; i >= 60; i -= 5)
                {
                    await Task.Delay(1);
                    stackNavbar.Width = i;
                }
                btnNavbar.IsEnabled = true;
            }
        }

        private void btnClock_MouseEnter(object sender, MouseEventArgs e)
        {
            Color backColor = Color.FromRgb(70, 70, 70);
            SolidColorBrush brush = new SolidColorBrush(backColor);
            btnClock.Background = brush;
        }

        private void btnClock_MouseLeave(object sender, MouseEventArgs e)
        {
            Color backColor = Color.FromRgb(37,37,37);
            SolidColorBrush brush = new SolidColorBrush(backColor);
            btnClock.Background = brush;
        }

        private void btnStoper_MouseEnter(object sender, MouseEventArgs e)
        {
            Color backColor = Color.FromRgb(70, 70, 70);
            SolidColorBrush brush = new SolidColorBrush(backColor);
            btnStoper.Background = brush;
        }

        private void btnStoper_MouseLeave(object sender, MouseEventArgs e)
        {

            Color backColor = Color.FromRgb(37, 37, 37);
            SolidColorBrush brush = new SolidColorBrush(backColor);
            btnStoper.Background = brush;
        }
    }
}