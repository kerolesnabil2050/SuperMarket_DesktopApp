using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : UserControl
    {
        Context context = new Context();
        public Product()
        {
            InitializeComponent();
            Fillcategory();
            FillSupplierCombox();
        }

        private void FillSupplierCombox()
        {
            SupplierCB.ItemsSource = context.suppliers.Where(e => e.IsDelete == false).ToList();
        }
        private void FillgridWithCustomizedCategory()
        {
            Categorys cate = CateogryCB.SelectedItem as Categorys;
            List<Proudect> products = context.proudcts.Where(p => p.CategorysId == cate.Id && p.IsDelete == false).ToList();
            datagrid.ItemsSource = products;
        }


        private void Fillcategory()
        {
            CateogryCB.ItemsSource = context.Categorys.Where(e => e.IsDelete == false).ToList();

        }
        //Add
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CateogryCB.SelectedItem != null && SupplierCB.SelectedItem != null && txtname.Text != "" && prodDate.SelectedDate.Value != null && expireDate.SelectedDate.Value != null && txtPurchasing.Text != "" && txtselling.Text != "")
            {
                double selling_price = double.Parse(txtselling.Text);
                double purchasing_price = double.Parse(txtPurchasing.Text);

                if (selling_price > purchasing_price)
                {

                    int valueCompare = DateTime.Compare(expireDate.SelectedDate.Value, prodDate.SelectedDate.Value);
                    if (valueCompare > 0)
                    {

                        //to check for duplicate product name
                        bool flag = false;
                        List<string> product_Name = context.proudcts.Select(s => s.Name).ToList();
                        foreach (string stor in product_Name)
                        {
                            if (txtname.Text == stor)
                            {
                                flag = true;
                            }
                        }

                        if (flag == false)
                        {
                            Categorys cate = CateogryCB.SelectedItem as Categorys;
                            Suppliers supp = SupplierCB.SelectedItem as Suppliers;
                            context.proudcts.Add(new Proudect { CategorysId = cate.Id, Suppliersid = supp.Id, Name = txtname.Text, SellingPrice = Convert.ToInt32(txtselling.Text), PurchasingPrice = Convert.ToInt32(txtPurchasing.Text), ProductionDate = prodDate.SelectedDate.Value, ExpirationDate = expireDate.SelectedDate.Value });
                            context.SaveChanges();
                            datagrid.ItemsSource = "";
                            FillgridWithCustomizedCategory();
                        }
                        else
                        {
                            MessageBox.Show("You have already the same product name");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Expiration Date must me later than Production Date ");
                    }
                }
                else
                {
                    MessageBox.Show("Selling Price Must Be Greater Than Purchasing Price");
                }
            }
            else
            {
                MessageBox.Show("You Must Fill All The Data First!");
            }

        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Categorys cate = CateogryCB.SelectedItem as Categorys;

            IQueryable<List<Proudect>> products =
                 context.Categorys.Where(e => e.Id == cate.Id && e.IsDelete == false).Select(e => e.Products.Where(e => e.IsDelete == false).ToList());

            foreach (List<Proudect> item in products)
            {
                datagrid.ItemsSource = item;
            }

        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Proudect selecteditem = datagrid.SelectedItem as Proudect;
            if (selecteditem != null)
            {
                var properites = selecteditem.GetType().GetProperties();

                txtname.Text = properites[1].GetValue(selecteditem).ToString();
                txtselling.Text = properites[2].GetValue(selecteditem).ToString();
                txtPurchasing.Text = properites[3].GetValue(selecteditem).ToString();
                prodDate.Text = properites[5].GetValue(selecteditem).ToString();
                expireDate.Text = properites[6].GetValue(selecteditem).ToString();


            }

        }

        //update
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CateogryCB.SelectedItem != null && SupplierCB.SelectedItem != null && txtname.Text != "" && prodDate.SelectedDate.Value != null && expireDate.SelectedDate.Value != null && txtPurchasing.Text != "" && txtselling.Text != "")
            {
                int valueCompare = DateTime.Compare(expireDate.SelectedDate.Value, prodDate.SelectedDate.Value);
                if (valueCompare > 0)
                {
                    Proudect pro = datagrid.SelectedItem as Proudect;
                    if (pro != null)
                    {

                        Proudect productt = context.proudcts.Where(s => s.Id == pro.Id && s.IsDelete == false).FirstOrDefault();

                        //to check for duplicate product name
                        bool flag = false;
                        List<string> product_Name = context.proudcts.Select(s => s.Name).ToList();
                        foreach (string stor in product_Name)
                        {
                            if (txtname.Text == stor)
                            {
                                flag = true;
                            }
                        }

                        if (flag == false)
                        {
                            productt.Name = txtname.Text;
                            productt.SellingPrice = Convert.ToDouble(txtselling.Text);
                            productt.PurchasingPrice = Convert.ToDouble(txtPurchasing.Text);
                            productt.ProductionDate = prodDate.SelectedDate.Value;
                            productt.ExpirationDate = expireDate.SelectedDate.Value;

                            context.SaveChanges();
                            datagrid.ItemsSource = "";
                            FillgridWithCustomizedCategory();
                            clear();
                        }
                        else
                        {
                            MessageBox.Show("You have already the same product name");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Expiration Date must me later than Production Date ");
                }  
            }
            else
            {
                MessageBox.Show("You Have To Select The Product Row First");
            }
        }

        //delete
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CateogryCB.SelectedItem != null && SupplierCB.SelectedItem != null && txtname.Text != "" && prodDate.SelectedDate.Value != null && expireDate.SelectedDate.Value != null && txtPurchasing.Text != "" && txtselling.Text != "")
            {
                MessageBoxResult result = MessageBox.Show("Are you sure to delete ", "Warning", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    Proudect pro = datagrid.SelectedItem as Proudect;
                    if (pro != null)
                    {

                        Proudect productt = context.proudcts.Where(s => s.Id == pro.Id && s.IsDelete == false).FirstOrDefault();
                        productt.IsDelete = true;
                        context.SaveChanges();
                        datagrid.ItemsSource = "";
                        FillgridWithCustomizedCategory();
                        clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("You Have To Select The Product Row First");
            }
        }

        private void clear()
        {
            txtname.Clear();
            txtselling.Clear();
            txtPurchasing.Clear();


        }

        public static bool IsValid(string str)
        {
            long i;
            return long.TryParse(str, out i) && i >= 0 && i <= 99999;
        }

        private void txtPurchasing_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }

        private void txtselling_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }
    }
}
