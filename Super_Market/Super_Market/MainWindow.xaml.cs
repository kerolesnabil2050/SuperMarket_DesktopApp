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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Context context = new Context();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string admin = comboValue.Text;

            if (admin == "Admin")
            {
                var AdminQuery = context.users.Where(usr => usr.Pos == (position)1&&usr.IsDelete==false).ToList();
                foreach (var usr in AdminQuery)
                {
                    if ((txtUsrName.Text == usr.UserName) && (txtPass.Password == usr.Password))
                    {
                        MessageBox.Show($"Welcome {usr.UserName}", "Welcomed", MessageBoxButton.OK, MessageBoxImage.Information);
                        Login.Content = new Admin(txtUsrName.Text);

                    }


                }

            }

            else if (admin == "Casher")
            {
                var casherQuery = context.users.Where(usr => usr.Pos == 0).ToList();
                foreach (var cas in casherQuery)
                {
                    if ((txtUsrName.Text == cas.UserName) && (txtPass.Password == cas.Password))
                    {
                        MessageBox.Show($"Welcome {cas.UserName}", "Welcomed", MessageBoxButton.OK, MessageBoxImage.Information);
                        Login.Content = new Casher(txtUsrName.Text);
                    }

                }

            }
            else
            {
                MessageBox.Show("wrong");
            }
        }
       

        private void Login_PreviewKeyDown(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void Login_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string admin = comboValue.Text;

                if (admin == "Admin")
                {
                    var AdminQuery = context.users.Where(usr => usr.Pos == (position)1).ToList();
                    foreach (var usr in AdminQuery)
                    {
                        if ((txtUsrName.Text == usr.UserName) && (txtPass.Password == usr.Password))
                        {
                            MessageBox.Show($"Welcome {usr.UserName}", "Welcomed", MessageBoxButton.OK, MessageBoxImage.Information);
                            Login.Content = new Admin(txtUsrName.Text);

                        }


                    }

                }

                else if (admin == "Casher")
                {
                    var casherQuery = context.users.Where(usr => usr.Pos == 0).ToList();
                    foreach (var cas in casherQuery)
                    {
                        if ((txtUsrName.Text == cas.UserName) && (txtPass.Password == cas.Password))
                        {
                            MessageBox.Show($"Welcome {cas.UserName}", "Welcomed", MessageBoxButton.OK, MessageBoxImage.Information);
                            Login.Content = new Casher(txtUsrName.Text);
                        }

                    }

                }
                else
                {
                    MessageBox.Show("wrong");
                }
            }
        }
    }
}
