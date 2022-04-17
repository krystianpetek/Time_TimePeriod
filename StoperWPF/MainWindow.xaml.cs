using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Stoper_Zegar_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StoperView stoperView;
        private ClockView clockView;

        private bool isVisibleNavbar = false;

        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new WelcomeView();
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
            Color backColor = Color.FromRgb(37, 37, 37);
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

        private void btnClock_MouseDown(object sender, MouseEventArgs e)
        {
            if (clockView == null)
                clockView = new ClockView();
            Main.Content = clockView;
        }

        private void btnStoper_MouseDown(object sender, MouseEventArgs e)
        {
            if (stoperView == null)
                stoperView = new StoperView();
            Main.Content = stoperView;
        }
    }
}