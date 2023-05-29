using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
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
    /// Interaction logic for Category.xaml
    /// </summary>
    public partial class Category : UserControl
    {
        Context context = new Context();
        public Category()
        {
            InitializeComponent();
            Fill_Combox_WithStore();
        }

        private void Fill_Combox_WithStore()
        {
            store_combo.ItemsSource = context.Stors.Where(e => e.IsDelete == false).ToList();

        }

        private void store_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            datagrid.ItemsSource = "";

            Stor storee = (Stor)store_combo.SelectedItem;
            IQueryable<List<Categorys>> categorys = context.Stors.Where(s => s.Id == storee.Id && s.IsDelete == false).Select(s => s.Categories.Where(r => r.IsDelete == false).ToList());

            foreach (List<Categorys> item in categorys)
            {
                datagrid.ItemsSource = item;
            }

        }

        /* Add */
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (CategoryTxt.Text != "" && store_combo.SelectedItem != null)
            {

                //to check for duplicate category name
                bool flag = false;
                List<string> category_Name = context.Categorys.Select(s => s.Name).ToList();
                foreach (string storr in category_Name)
                {
                    if (CategoryTxt.Text == storr)
                    {
                        flag = true;
                    }
                }

                if (flag == false)
                {

                    Stor stores = (Stor)store_combo.SelectedItem;
                    context.Categorys.Add(new Categorys { Name = CategoryTxt.Text, StorId = stores.Id });
                    context.SaveChanges();

                    datagrid.ItemsSource = "";
                    /* Fill Data Grid With New Categories*/
                    IQueryable<List<Categorys>> categorys = context.Stors.Where(s => s.Id == stores.Id && s.IsDelete == false).Select(s => s.Categories.Where(e => e.IsDelete == false).ToList());

                    foreach (List<Categorys> item in categorys)
                    {
                        datagrid.ItemsSource = item;
                    }
                    /* End */
                    CategoryTxt.Text = "";
                }
                else
                {
                    MessageBox.Show("You have already the same category name");
                }

            }
     
            else
            {
                MessageBox.Show("You Have To Fill The Data First");
            }
        }

        /* Update */
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (CategoryTxt.Text != "" && store_combo.SelectedItem != null)
            {
                Categorys category = datagrid.SelectedItem as Categorys;
                if (category != null)
                {

                    Categorys cate = context.Categorys.Where(c => c.Id == category.Id && c.IsDelete == false).FirstOrDefault();

                    //to check for duplicate category name
                    bool flag = false;
                    List<string> category_Name = context.Categorys.Select(s => s.Name).ToList();
                    foreach (string storr in category_Name)
                    {
                        if (CategoryTxt.Text == storr)
                        {
                            flag = true;
                        }
                    }

                    //if (flag == false)
                    //{

                        cate.Name = CategoryTxt.Text;
                        context.SaveChanges();

                        datagrid.ItemsSource = "";
                        /* Fill Data Grid With Updated Categories*/
                        Stor stores = (Stor)store_combo.SelectedItem;
                        IQueryable<List<Categorys>> categories = context.Stors.Where(s => s.Id == stores.Id && s.IsDelete == false).Select(s => s.Categories.Where(e => e.IsDelete == false).ToList());

                        foreach (List<Categorys> item in categories)
                        {
                            datagrid.ItemsSource = item;
                        }
                        /* End */
                        CategoryTxt.Text = " ";
                    //}
                    //else
                    //{
                    //    MessageBox.Show("You have already the same category name");
                    //}
                }
            }
            else
            {
                MessageBox.Show("You Have To Select The Category Row First");
            }

        }

        /* Delete */
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CategoryTxt.Text != "" && store_combo.SelectedItem != null)
            {
                MessageBoxResult message = MessageBox.Show("Are You sure you want to delete", "Warning", MessageBoxButton.YesNo);
                if (message == MessageBoxResult.Yes)
                {
                    Categorys category = datagrid.SelectedItem as Categorys;

                    if (category != null)
                    {
                        Categorys cate = context.Categorys.Where(c => c.Id == category.Id).FirstOrDefault();
                        //context.Categorys.Remove(query);
                        cate.IsDelete = true;
                        context.SaveChanges();
                        datagrid.ItemsSource = "";
                        /* Fill Data Grid With Categories*/

                        Stor stores = (Stor)store_combo.SelectedItem;
                        IQueryable<List<Categorys>> categorys = context.Stors.Where(s => s.Id == stores.Id && s.IsDelete == false).Select(s => s.Categories.Where(e => e.IsDelete == false).ToList());


                        foreach (List<Categorys> item in categorys)
                        {

                            datagrid.ItemsSource = item;
                        }
                        /* End */

                        CategoryTxt.Text = " ";
                    }
                }
            }
            else
            {
                MessageBox.Show("You Have To Select The Category Row First");
            }
        }


        private void datagrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
           Categorys selectedItem = datagrid.SelectedItem as Categorys; 

            if (selectedItem != null)
            {
                var properties = selectedItem.GetType().GetProperties();
                CategoryTxt.Text = properties[1].GetValue(selectedItem).ToString();
            }
        }
    }
}
