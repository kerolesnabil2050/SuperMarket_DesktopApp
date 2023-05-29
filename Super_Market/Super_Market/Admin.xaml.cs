using Microsoft.Identity.Client;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Super_Market
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : UserControl
    {
        Context Context = new Context();
        public string UserName = "";
        public Admin(string name)
        {
            InitializeComponent();
            UserName = name;
            

        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

            stores.Content = new Store();
        }

        private void list_2_Selected(object sender, RoutedEventArgs e)
        {
            stores.Content = new Category();
        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            stores.Content = new Product();
        }

        private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
        {
            stores.Content = new Sales(UserName);
        }

        private void ListViewItem_Selected_3(object sender, RoutedEventArgs e)
        {
            stores.Content = new Purchase();
        }

        private void ListViewItem_Selected_4(object sender, RoutedEventArgs e)
        {
            stores.Content = new Report();
        }

        private void ListViewItem_Selected_5(object sender, RoutedEventArgs e)
        {
            stores.Content = new Retrieval();
           
        }

        private void ListViewItem_Selected_6(object sender, RoutedEventArgs e)
        {

            MainWindow window = new MainWindow();
            window.Show();
            Window.GetWindow(this).Close();
        }

        private void ListViewItem_Selected_7(object sender, RoutedEventArgs e)
        {
            stores.Content = new Supplier();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Window window = Window.GetWindow(this);
            if (window.WindowState == WindowState.Maximized)
            {
                window.WindowState = WindowState.Normal;
            }
            else
            {
                window.WindowState = WindowState.Maximized;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


    }
}
