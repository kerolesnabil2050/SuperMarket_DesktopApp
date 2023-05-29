using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Store.xaml
    /// </summary>
    public partial class Store : UserControl
    {
        Context context = new Context();
        public Store()
        {
            InitializeComponent();
            Fillgrid();
           
        }

        private void Fillgrid()
        {
            datagrid.ItemsSource = context.Stors.Where(e => e.IsDelete == false).ToList();
        }

       
        //add
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (txtstor.Text == "" || txtloc.Text == "")
            {
                MessageBox.Show("Please Add Store Or Location");
            }

            else
            {
              //to check for duplicate store name
                bool flag = false;
                List<string> stors_Name=context.Stors.Where(w=>w.IsDelete==false).Select(s => s.Name).ToList();
                foreach(string stor in stors_Name)
                {
                    if(txtstor.Text==stor)
                    {
                        flag = true;
                    }
                }

                if (flag==false)
                {
                    context.Stors.Add(new Stor { Name = txtstor.Text, Location = txtloc.Text });
                    context.SaveChanges();
                    datagrid.ItemsSource = "";
                    Fillgrid();
                    txtloc.Text = "";
                    txtstor.Text = "";
                }
                else
                {
                    MessageBox.Show("You have already the same store name");
                }
            }
        }
        //update
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (txtstor.Text == "" || txtloc.Text == "")
            {
                MessageBox.Show("You Must Select the Store Row First!");
            }
            else
            {
                Stor selectedItem = datagrid.SelectedItem as Stor;
                if (selectedItem != null)
                {
                    var properties = selectedItem.GetType().GetProperties();
                    int id = Convert.ToInt32(properties[0].GetValue(selectedItem));
                    Stor stor = context.Stors.Where(s => s.Id == id && s.IsDelete == false).FirstOrDefault();

                    //to check for duplicate store name
                    bool flag = false;
                    List<string> stors_Name = context.Stors.Where(e=>e.IsDelete==false).Select(s => s.Name).ToList();
                    foreach (string storr in stors_Name)
                    {
                        if (txtstor.Text == storr)
                        {
                            flag = true;
                        }
                    }

                    //if (flag == false)
                    //{
                        stor.Name = txtstor.Text;
                        stor.Location = txtloc.Text;
                        context.SaveChanges();
                        datagrid.ItemsSource = "";
                        Fillgrid();
                        txtloc.Text = "";
                        txtstor.Text = "";
                   // }
                   // else
                   // {
                    //    MessageBox.Show("You have already the same store name");
                    //}

                }
                else
                {
                    MessageBox.Show("You Must Select the Store Row First!");
                }
            }
        }

        //delete
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           
            if (txtstor.Text != "" || txtloc.Text != "")
            { 
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete", "Waring", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    Stor stor = context.Stors.Where(s => s.Name == txtstor.Text && s.IsDelete == false).FirstOrDefault();
                    if (stor != null)
                    {
                        //context.Stors.Remove(stor);
                        stor.IsDelete = true;
                        context.SaveChanges();
                        datagrid.ItemsSource = "";
                        Fillgrid();
                        txtloc.Text = "";
                        txtstor.Text = "";
                    }
                  
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("You Must Select the Store Row First!");
            }
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Stor selecteditem = datagrid.SelectedItem as Stor;
            if (selecteditem != null)
            {
                var properites = selecteditem.GetType().GetProperties();
                txtstor.Text = properites[1].GetValue(selecteditem).ToString();
                txtloc.Text = properites[2].GetValue(selecteditem).ToString();
            }

        }

      
    }
}
