using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataGridTextColumn = System.Windows.Controls.DataGridTextColumn;

namespace Super_Market
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : UserControl
    {
        Context context = new Context();
        public Report()
        {
            InitializeComponent();
            Reportproduct.ItemsSource = context.proudcts.ToList();

            Combobox_Suppliers.ItemsSource = context.suppliers.Where(e => e.IsDelete == false).ToList();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //sell invoce
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (Date.SelectedDate != null)
            {
                datagrid.Columns.Clear();
                DateTime date = Convert.ToDateTime(Date.SelectedDate.Value).Date;
               // MessageBox.Show($"{date}");
                var invoces = context.sellinvoces.Where(d => d.DateTime.Date == date && d.IsDelete == false);

                DataGridTextColumn BoneColumn = new DataGridTextColumn();
                BoneColumn.Header = "BonNumber";
                BoneColumn.Binding = new Binding("BonNumberr");
                datagrid.Columns.Add(BoneColumn);

                DataGridTextColumn UserColumn = new DataGridTextColumn();
                UserColumn.Header = "User";
                UserColumn.Binding = new Binding("UsersId");
                datagrid.Columns.Add(UserColumn);

                DataGridTextColumn datetime = new DataGridTextColumn();
                datetime.Header = "DateTime";
                datetime.Binding = new Binding("DateTime");
                datagrid.Columns.Add(datetime);

                DataGridTextColumn totalprice = new DataGridTextColumn();
                totalprice.Header = "TotalPrice";
                totalprice.Binding = new Binding("TotalPrice");
                datagrid.Columns.Add(totalprice);

                DataGridTextColumn paidmoney = new DataGridTextColumn();
                paidmoney.Header = "PaidMoney";
                paidmoney.Binding = new Binding("PaidMoney");
                datagrid.Columns.Add(paidmoney);

                DataGridTextColumn reminmoney = new DataGridTextColumn();
                reminmoney.Header = "RemainingMoney";
                reminmoney.Binding = new Binding("RemainingMoney");
                datagrid.Columns.Add(reminmoney);

                datagrid.ItemsSource = invoces.ToList();
            }
            else
            {
                MessageBox.Show("Please Fill all Required Data");
            }
        }

        //Purchase invoce
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            if (Combobox_Suppliers.SelectedItem != null && Date.SelectedDate != null)
            {
                datagrid.Columns.Clear();
                Suppliers supplier = (Suppliers)Combobox_Suppliers.SelectedItem;
                DateTime date = Convert.ToDateTime(Date.SelectedDate.Value).Date;
                var invoces = context.recipts.Where(d => d.DateTime.Date == date && d.SuppliersId == supplier.Id && d.IsDelete == false);

                DataGridTextColumn BoneColumn = new DataGridTextColumn();
                BoneColumn.Header = "BonNumber";
                BoneColumn.Binding = new Binding("Id");
                datagrid.Columns.Add(BoneColumn);

                DataGridTextColumn SupplierColumn = new DataGridTextColumn();
                SupplierColumn.Header = "Supplier";
                SupplierColumn.Binding = new Binding("SuppliersId");
                datagrid.Columns.Add(SupplierColumn);

                DataGridTextColumn datetime = new DataGridTextColumn();
                datetime.Header = "DateTime";
                datetime.Binding = new Binding("DateTime");
                datagrid.Columns.Add(datetime);

                DataGridTextColumn totalprice = new DataGridTextColumn();
                totalprice.Header = "TotalPrice";
                totalprice.Binding = new Binding("Total");
                datagrid.Columns.Add(totalprice);


                datagrid.ItemsSource = invoces.ToList();

            }
            else
            {
                MessageBox.Show("Please Fill all Required Data");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}