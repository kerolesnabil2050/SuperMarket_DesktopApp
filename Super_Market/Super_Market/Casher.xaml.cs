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
    /// Interaction logic for Casher.xaml
    /// </summary>
    public partial class Casher : UserControl
    {
        public string UserName = "";
        Context context = new Context();
        public Casher(string name)
        {
            InitializeComponent();
            combstor.ItemsSource = context.Stors.Where(e => e.IsDelete == false).ToList();
            UserName = name;
            Cashername.Text = UserName;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comcat.SelectedItem != null)
            {
                Categorys categor = (Categorys)comcat.SelectedItem;
                combproduct.ItemsSource = context.proudcts.Where(p => p.category.Id == categor.Id && p.IsDelete == false).ToList();
            }
        }

        private void combstor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var store = (Stor)combstor.SelectedItem;
            comcat.ItemsSource = context.Categorys.Where(e => e.objstor.Id == store.Id && e.IsDelete == false).ToList();
            combproduct.ItemsSource = "";
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (combproduct.SelectedItem != null)
            {
                Proudect product = (Proudect)combproduct.SelectedItem;
                Proudect proudects = context.proudcts.Where(p => p.Id == product.Id && p.IsDelete == false).FirstOrDefault();
                Txtsel.Text = proudects.SellingPrice.ToString();
                txtTotQua.Text = product.Quantity.ToString();
                TxtQua.Text = "1";
                TxtDis.Text = "0";
                TxtData.Text = DateTime.Now.ToString();
                TxtproductName.Text = product.Name;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (combproduct.SelectedItem != null && TxtproductName.Text != "")
            {
                Proudect proudect = (Proudect)combproduct.SelectedItem;
                string ProductName = proudect.Name;
                int.TryParse(txtTotQua.Text, out int AllQuantity);
                int.TryParse(TxtQua.Text, out int QuantityUserEnter);
                if (QuantityUserEnter > AllQuantity || QuantityUserEnter == 0)
                {
                    MessageBox.Show($"This Quantity of : {ProductName} More than Total in Store", "alert", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    AllQuantity -= QuantityUserEnter;
                    txtTotQua.Text = AllQuantity.ToString();
                }

                int TotalPrice = QuantityUserEnter * int.Parse(Txtsel.Text);
                double.TryParse(TxtDis.Text, out double Dis);
                double discount;
                if (Dis > 0)
                {
                    discount = (TotalPrice * Dis) / 100;
                }
                else
                {
                    discount = 0;
                }

                double totalafterPrice = TotalPrice - discount;
                var list = new[]
                   {
                    new { Name =ProductName, Quantity = TxtQua.Text,
                                   Total=TotalPrice.ToString(),Discount=discount,
                                   TotalAfterDiscount=totalafterPrice
                    }
             }.ToList();


                SalesDataGraid.Items.Add(list);
                Proudect p = context.proudcts.Where(e => e.Name == ProductName).FirstOrDefault();
                p.Quantity = AllQuantity;
                context.SaveChanges();
            }


            else
            {
                MessageBox.Show("You must choose item first", "alert", MessageBoxButton.OK);
            }




        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            object item1 = SalesDataGraid.SelectedItem;
            if (item1 != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want delete", "alert", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    int QuantityReriveToDatabase = 0;
                    if (TxtQua.Text == (SalesDataGraid.SelectedCells[1].Column.GetCellContent(item1) as TextBlock).Text)
                    {
                        QuantityReriveToDatabase = int.Parse(TxtQua.Text);

                        Proudect product2 = context.proudcts.Where(e => e.Name == TxtproductName.Text && e.IsDelete == false).FirstOrDefault();
                        product2.Quantity += QuantityReriveToDatabase;
                        context.SaveChanges();
                        txtTotQua.Text = product2.Quantity.ToString();
                        TxtQua.Text = "1";
                        SalesDataGraid.Items.Remove(item1);
                        lbltoAfter.Text = "";
                        lbltotpri.Text = "";
                    }
                }
                else
                {
                    return;
                }
            }

        }

        private void SalesDataGraid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SalesDataGraid.SelectedItem != null)
            {
                int y = 0;
                object item1 = SalesDataGraid.SelectedItem;
                TxtproductName.Text = (SalesDataGraid.SelectedCells[0].Column.GetCellContent(item1) as TextBlock).Text;
                TxtQua.Text = (SalesDataGraid.SelectedCells[1].Column.GetCellContent(item1) as TextBlock).Text;
                string DiscountInDataGrid = (SalesDataGraid.SelectedCells[3].Column.GetCellContent(item1) as TextBlock).Text;
                Proudect product = context.proudcts.Where(e => e.Name == TxtproductName.Text && e.IsDelete == false).FirstOrDefault();
                if (product != null)
                {
                    Txtsel.Text = product.SellingPrice.ToString();
                    txtTotQua.Text = product.Quantity.ToString();
                }
                double.TryParse(DiscountInDataGrid, out double Discount);
                int.TryParse(Txtsel.Text, out int SellPrice);
                int.TryParse(TxtQua.Text, out int Quantity);

                int TotalAfterDiscount = SellPrice * Quantity;
                double convertdiscount = (Discount * 100) / TotalAfterDiscount;
                TxtDis.Text = convertdiscount.ToString();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (SalesDataGraid.SelectedItem != null)
            {
                object salesGrid = SalesDataGraid.SelectedItem;
                int QuauanityInGrid = int.Parse((SalesDataGraid.SelectedCells[1].Column.GetCellContent(salesGrid) as TextBlock).Text);

                (SalesDataGraid.SelectedCells[0].Column.GetCellContent(salesGrid) as TextBlock).Text = TxtproductName.Text;
                (SalesDataGraid.SelectedCells[1].Column.GetCellContent(salesGrid) as TextBlock).Text = TxtQua.Text;
                int Total = int.Parse(TxtQua.Text) * int.Parse(Txtsel.Text);
                (SalesDataGraid.SelectedCells[2].Column.GetCellContent(salesGrid) as TextBlock).Text = Total.ToString();
                double TotalAfterDiscount = (Total * double.Parse(TxtDis.Text)) / 100;
                (SalesDataGraid.SelectedCells[3].Column.GetCellContent(salesGrid) as TextBlock).Text = TotalAfterDiscount.ToString();
                double y = Total - (Total * double.Parse(TxtDis.Text)) / 100;
                (SalesDataGraid.SelectedCells[4].Column.GetCellContent(salesGrid) as TextBlock).Text = y.ToString();
                int QuantityInText = int.Parse(TxtQua.Text);
                int valueinDatabase = 0;
                if (QuauanityInGrid != QuantityInText)
                {
                    if (QuauanityInGrid > QuantityInText)
                    {
                        valueinDatabase = QuauanityInGrid - QuantityInText;
                        Proudect product = context.proudcts.Where(e => e.Name == TxtproductName.Text && e.IsDelete == false).FirstOrDefault();
                        product.Quantity += valueinDatabase;
                        context.SaveChanges();
                        txtTotQua.Text = product.Quantity.ToString();
                    }
                    else
                    {
                        valueinDatabase = QuantityInText - QuauanityInGrid;
                        Proudect product2 = context.proudcts.Where(e => e.Name == TxtproductName.Text && e.IsDelete == false).FirstOrDefault();
                        product2.Quantity -= valueinDatabase;
                        context.SaveChanges();
                        txtTotQua.Text = product2.Quantity.ToString();
                    }
                    lbltotpri.Text = "";
                    lbltoAfter.Text = "";
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            double totalBeforeDis = 0;
            double totalAfterDis = 0;

            if (SalesDataGraid.Items.Count > 0)
            {

                for (int i = 0; i < SalesDataGraid.Items.Count; i++)
                {

                    string Total = (SalesDataGraid.Columns[2].GetCellContent(SalesDataGraid.Items[i]) as TextBlock).Text;
                    string TotalAfterDicount = (SalesDataGraid.Columns[4].GetCellContent(SalesDataGraid.Items[i]) as TextBlock).Text;


                    totalBeforeDis += double.Parse(Total);
                    totalAfterDis += double.Parse(TotalAfterDicount);
                }


                lbltotpri.Text = totalBeforeDis.ToString();
                lbltoAfter.Text = totalAfterDis.ToString();
            }
            else
            {
                MessageBox.Show("you must enter product first", "alert", MessageBoxButton.YesNo);

            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            double.TryParse(TxtPaiMon.Text, out double paidMony);
            double.TryParse(lbltoAfter.Text, out double total);
            if (paidMony >= total && paidMony != 0 && SalesDataGraid.Items.Count > 0)
            {
                double remaind = paidMony - total;
                LblRem.Text = remaind.ToString();

            }
            else
            {
                MessageBox.Show("the Money less than total", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

            if (lbltotpri.Text != "" && TxtPaiMon.Text != "" && SalesDataGraid.Items.Count > 0 && LblRem.Text != "")
            {
                Users user = context.users.Where(e => e.UserName == UserName && e.IsDelete == false).FirstOrDefault();
                Sellinvoce sellinvoce = new Sellinvoce();
                sellinvoce.DateTime = DateTime.Now;
                sellinvoce.UsersId = user.Id;
                sellinvoce.RemainingMoney = double.Parse(LblRem.Text);
                sellinvoce.PaidMoney = double.Parse(TxtPaiMon.Text);
                sellinvoce.TotalPrice = double.Parse(lbltoAfter.Text);
                context.sellinvoces.Add(sellinvoce);
                context.SaveChanges();
                for (int i = 0; i < SalesDataGraid.Items.Count; i++)
                {
                    Order order = new Order();
                    string name = (SalesDataGraid.Columns[0].GetCellContent(SalesDataGraid.Items[i]) as TextBlock).Text;
                    string Quuantity = (SalesDataGraid.Columns[1].GetCellContent(SalesDataGraid.Items[i]) as TextBlock).Text;
                    int quan = int.Parse(Quuantity);
                    Proudect product = context.proudcts.Where(e => e.Name == name && e.IsDelete == false).FirstOrDefault();
                    order.ProudectId = product.Id;
                    order.Quanatity = quan;
                    order.SellinvoceId = sellinvoce.BonNumberr;
                    context.orders.Add(order);
                    context.SaveChanges();
                }
                bon_number.Text = sellinvoce.BonNumberr.ToString();
                if (SalesDataGraid.Items.Count > 0)


                    SalesDataGraid.Items.Clear();
                LblRem.Text = "0";
                lbltotpri.Text = "";
                TxtPaiMon.Text = "";
                lbltoAfter.Text = "";
                TxtData.Text = "";
                TxtproductName.Text = "";
                TxtQua.Text = "";
                Txtsel.Text = "";
                txtTotQua.Text = "";
                TxtDis.Text = "";
                SalesDataGraid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("You Must Enter Product first", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Minimize(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.WindowState = WindowState.Minimized;
        }

        private void Maximize_Minimize(object sender, RoutedEventArgs e)
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

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Numericonly(object sender, TextCompositionEventArgs e)
        {

            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }
        private void BonNumriconly(object sender, TextCompositionEventArgs e)
        {

            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }
        public static bool IsValid(string str)
        {
            int i;
            return int.TryParse(str, out i) && i >= 0 && i <= 9999;
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Window.GetWindow(this).Close();
        }
    }
}
