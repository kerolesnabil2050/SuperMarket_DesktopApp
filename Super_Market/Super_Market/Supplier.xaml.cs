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
    /// Interaction logic for Supplier.xaml
    /// </summary>
    public partial class Supplier : UserControl
    {
        Context context = new Context();
        public Supplier()
        {
            InitializeComponent();
            fillDataGrid();
        }
        private void fillDataGrid()
        {
            datagrid.ItemsSource = context.suppliers.Where(e => e.IsDelete == false).ToList();
        }
        private void clearInputs()
        {
            txtName.Clear();
            txtPhone.Clear();
        }

        //Add
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "" && txtPhone.Text != "")
            {

                //to check for duplicate supplier name
                bool flag = false;
                List<string> supplier_Name = context.suppliers.Select(s => s.Name).ToList();
                foreach (string storr in supplier_Name)
                {
                    if (txtName.Text == storr)
                    {
                        flag = true;
                    }
                }

                if (flag == false)
                {

                    if (txtPhone.Text.Length == 11)
                    {
                        context.suppliers.Add(new Suppliers { Name = txtName.Text, Phone = txtPhone.Text });
                        context.SaveChanges();
                        datagrid.ItemsSource = "";
                        fillDataGrid();
                        clearInputs();
                    }
                    else
                    {
                        MessageBox.Show("The Length of Phone Must Be 11 Numbers Or Phone Number Must be Numbers Only");
                    }
                }
                else
                {
                       MessageBox.Show("You have already the same supplier name");
                }
            }
            else
            {
                MessageBox.Show("You Have To Fill The Data First");
            }

        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Suppliers selecteditem = datagrid.SelectedItem as Suppliers;
            if (selecteditem != null)
            {
                var properites = selecteditem.GetType().GetProperties();
                txtName.Text = properites[1].GetValue(selecteditem).ToString();
                txtPhone.Text = properites[2].GetValue(selecteditem).ToString();
            }
        }

        //update
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "" && txtPhone.Text != "")
            {
                Suppliers supp = datagrid.SelectedItem as Suppliers;
                if (supp != null)
                {
                    Suppliers supplier = context.suppliers.Where(s => s.Id == supp.Id && s.IsDelete == false).FirstOrDefault();

                    bool flag = false;
                    List<string> supplier_Name = context.suppliers.Where(e=>e.IsDelete==false).Select(s => s.Name).ToList();
                    foreach (string storr in supplier_Name)
                    {
                        if (txtName.Text == storr)
                        {
                            flag = true;
                        }
                    }

                    //if (flag == false)
                    //{
                        supplier.Name = txtName.Text;
                        supplier.Phone = txtPhone.Text;
                        context.SaveChanges();

                        datagrid.ItemsSource = "";
                        fillDataGrid();
                        clearInputs();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("You have already the same supplier name");
                    //}

                }
            }
            else
            {
                MessageBox.Show("You Have To Select The Supplier Row First");
            }
        }

        //delete
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "" && txtPhone.Text != "")
            {
                MessageBoxResult result = MessageBox.Show("Are you sure to delete ", "Warning", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    Suppliers supp = datagrid.SelectedItem as Suppliers;
                    if (supp != null)
                    {
                        supp.IsDelete = true;
                        context.SaveChanges();

                        datagrid.ItemsSource = "";
                        fillDataGrid();
                        clearInputs();

                    }
                }
               
            }
            else
            {
                MessageBox.Show("You Have To Select The Supplier Row First");
            }
        }
        public static bool IsValid(string str)
        {
            long i;
            return long.TryParse(str, out i) && i >=0 && i <= 99999999999;
        }

        private void txtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }
    }
}
