using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Store_Pro.AdminPanel
{
    /// <summary>
    /// Interaction logic for Адмін_Панель.xaml
    /// </summary>
    public partial class Адмін_Панель : Window
    {
        public Адмін_Панель(string login, string password)
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            frame1.Source = new Uri("Golovna.xaml", UriKind.RelativeOrAbsolute);
            frame2.Source = new Uri("Stores.xaml", UriKind.RelativeOrAbsolute);
            frame3.Source = new Uri("Accounts.xaml", UriKind.RelativeOrAbsolute);
            //frame1.Content = new Golovna();
            //frame1.NavigationService.Navigate(new Golovna());

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame1.Visibility =Visibility.Visible;
            frame2.Visibility = Visibility.Hidden;
            frame3.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frame1.Visibility = Visibility.Hidden;
            frame2.Visibility = Visibility.Visible;
            frame3.Visibility = Visibility.Hidden;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            frame1.Visibility = Visibility.Hidden;
            frame2.Visibility = Visibility.Hidden;
            frame3.Visibility = Visibility.Visible;
        }
    }
}
