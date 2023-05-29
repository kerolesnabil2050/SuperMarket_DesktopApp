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
    /// Interaction logic for Retrieval.xaml
    /// </summary>
    public partial class Retrieval : UserControl
    {
        Context context = new Context();
        public Retrieval()
        {
            InitializeComponent();
        }
        private void Search_Button(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = "";
            int.TryParse(bon_numbersearch.Text, out int result);
            var sellinvoces = context.sellinvoces.Where(s => s.BonNumberr == result && s.IsDelete == false).Include(s => s.Orders.Where(o => o.IsDelete == false)).FirstOrDefault();
            if (sellinvoces != null)
            {
                if (sellinvoces.IsDiscount == true)
                {
                    MessageBox.Show("this sell have discount then the retriverd deny","inform",MessageBoxButton.OK);
                }
                else
                {
                    var list = Array.Empty<object>().ToList();
                    foreach (var order in sellinvoces.Orders.Where(e => e.IsDelete == false))
                    {
                        Proudect proudect = context.proudcts.Where(p => p.Id == order.ProudectId && p.IsDelete == false).FirstOrDefault();
                        list.Add(new { Name = proudect.Name, Quantity = order.Quanatity });
                    }
                    datagrid.ItemsSource = list;
                    totalprice.Text = sellinvoces.TotalPrice.ToString();

                }
            }
            else
            {
                MessageBox.Show("This SellInvoces Not Found");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagrid.SelectedItem != null)
            {
                object item1 = datagrid.SelectedItem;
                TxtproductName.Text = (datagrid.SelectedCells[0].Column.GetCellContent(item1) as TextBlock).Text;
                TxtQua.Text = (datagrid.SelectedCells[1].Column.GetCellContent(item1) as TextBlock).Text;
            }
        }

        private void Update_button(object sender, RoutedEventArgs e)
        {

            if (datagrid.SelectedItem != null && TxtQua.Text != "")
            {
                int deffir = 0;

                object item1 = datagrid.SelectedItem;
                int.TryParse(bon_numbersearch.Text, out int result);
                var sellinvoces = context.sellinvoces.Where(s => s.BonNumberr == result && s.IsDelete == false).Include(s => s.Orders.Where(e => e.IsDelete == false)).FirstOrDefault();
                if (sellinvoces != null)
                {

                    Proudect productt = (Proudect)context.proudcts.Where(p => p.Name == TxtproductName.Text && p.IsDelete == false).FirstOrDefault();
                    var order = sellinvoces.Orders.Where(s => s.ProudectId == productt.Id && s.IsDelete == false).FirstOrDefault();

                    int Txt_quent = Convert.ToInt32(TxtQua.Text);
                    if (Txt_quent <= order.Quanatity)
                    {
                        deffir = order.Quanatity - Txt_quent;
                        productt.Quantity += order.Quanatity - Txt_quent;
                        context.SaveChanges();
                        order.Quanatity = Txt_quent;
                        if (order.Quanatity == 0)
                        {
                            order.IsDelete = true;
                        }
                        context.SaveChanges();
                        (datagrid.SelectedCells[0].Column.GetCellContent(item1) as TextBlock).Text = TxtproductName.Text;
                        (datagrid.SelectedCells[1].Column.GetCellContent(item1) as TextBlock).Text = TxtQua.Text;
                        TxtproductName.Text = "";
                        TxtQua.Text = "";

                        int different = (int)(productt.SellingPrice * deffir);
                        sellinvoces.TotalPrice = sellinvoces.TotalPrice - different;
                        context.SaveChanges();
                        totalprice.Text = sellinvoces.TotalPrice.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Quentity larger than the old quentity");
                    }
                }
                datagrid.SelectedItem = null;

            }
        }

        private void NumericOnly(object sender, TextCompositionEventArgs e)
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
