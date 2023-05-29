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
    /// Interaction logic for Purchase.xaml
    /// </summary>
    public partial class Purchase : UserControl
    {
        Context context = new Context();

        public Purchase()
        {
            InitializeComponent();
            Supplier.ItemsSource = context.suppliers.Where(e => e.IsDelete == false).ToList();
            TxtTime.Text = DateTime.Now.ToString();
        }



        private void Suppliers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Suppliers supplier = (Suppliers)Supplier.SelectedItem;
            List<Proudect> proudect = context.proudcts.Where(s => s.supplier.Id == supplier.Id && s.IsDelete == false).ToList();

          
            product.ItemsSource = proudect;


        }

        private void product_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (product.SelectedItem != null)
            {
                IQueryable<List<Proudect> >pro = context.Categorys.Select(e => e.Products);
                foreach ( List < Proudect > item in pro)
                {
                    foreach (Proudect item2 in item)
                    {
                        if (item2.Name == product.SelectedValue.ToString())
                        {
                            textprice.Text = item2.PurchasingPrice.ToString();
                            txtproduct.Text = item2.Name;
                        }
                    }
                }

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)

        {
            int.TryParse(txtquantaty.Text, out int quantity);
            if (quantity == 0 || product.SelectedValue == null)
            {
                MessageBox.Show("please enter Quantity");
            }

            else
            {
                int price = int.Parse(textprice.Text);
                int Quantity = int.Parse(txtquantaty.Text);
                int priceofsingalitem = price * Quantity;

                var list = new[] { new { Name = product.SelectedItem, Quantity = txtquantaty.Text, PurchasePrice = priceofsingalitem.ToString() } }.ToList();
                datagrid.Items.Add(list);
                Supplier.IsEnabled = false;
                textprice.Text = "";
                txtquantaty.Text = "";
                txtproduct.Text = "";
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure ", "Warning", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var selectedItem = datagrid.SelectedItem ;
                if (selectedItem != null)
                {
                    datagrid.Items.Remove(selectedItem);
                }
                textprice.Text = "";
                txtquantaty.Text = "";
                txtproduct.Text = "";
            }
            else
            {
                return;
            }


        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var selectedItem = datagrid.SelectedItem;
            if (selectedItem != null)
            {
                (datagrid.SelectedCells[1].Column.GetCellContent(selectedItem) as TextBlock).Text = txtquantaty.Text;
            }

        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (datagrid.SelectedItem != null)
            {
                var item1 = datagrid.SelectedItem ;
                string proname = (datagrid.SelectedCells[0].Column.GetCellContent(item1) as TextBlock).Text;
                txtproduct.Text = proname;
                string quantaty = (datagrid.SelectedCells[1].Column.GetCellContent(item1) as TextBlock).Text;
                txtquantaty.Text = quantaty;
                double quantityInGrid = int.Parse(quantaty);

                string price = (datagrid.SelectedCells[2].Column.GetCellContent(item1) as TextBlock).Text;
                double PriceInDatagrid = int.Parse(price);
                double priceofspecific = PriceInDatagrid / quantityInGrid;
                textprice.Text = priceofspecific.ToString();

            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int sumPrice = 0;
   
            for (int i = 0; i < datagrid.Items.Count; i++)
            {
                string product_Name = (datagrid.Columns[0].GetCellContent(datagrid.Items[i]) as TextBlock).Text;
                string price = (datagrid.Columns[2].GetCellContent(datagrid.Items[i]) as TextBlock).Text;


                Proudect query = context.proudcts.Where(s => s.Name == product_Name && s.IsDelete == false).ToList().FirstOrDefault();

                if (query != null)
                {

                    query.Quantity += int.Parse((datagrid.Columns[1].GetCellContent(datagrid.Items[i]) as TextBlock).Text);

                    sumPrice += int.Parse(price);
                    
                    TotalPrice.Text = sumPrice.ToString();
                    context.SaveChanges();


                }

            }


        }


        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            if (datagrid.Items.Count == 0)
            {
               MessageBox.Show("Please Add Your Items");
            }
            else
            {

                Recipt recipt = new Recipt();
               

                    Suppliers supp = Supplier.SelectedItem as Suppliers;
                    Suppliers supid = context.suppliers.Where(r => r.Id == supp.Id && r.IsDelete == false).FirstOrDefault();

                    recipt.SuppliersId = supid.Id;
                    recipt.Total = int.Parse(TotalPrice.Text);
                    recipt.DateTime =DateTime.Now;


                context.recipts.Add(recipt);
                context.SaveChanges();
                Supplier.IsEnabled = true;


            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (datagrid.Items.Count > 0)
            {
                datagrid.Items.Clear();
                datagrid.Items.Refresh();
            }
            TotalPrice.Text = "";


        }

        private void NumericONly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }
        public static bool IsValid(string str)
        {
            int i;
            return int.TryParse(str, out i) && i >= 0 && i <= 9999;
        }
    }
}
