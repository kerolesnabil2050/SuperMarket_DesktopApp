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
using System.Windows.Shapes;

namespace Super_Market
{
    /// <summary>
    /// Interaction logic for PrintWindow.xaml
    /// </summary>
    public partial class PrintWindow : Window
    {
        Context context=new Context();
        public PrintWindow(int bon)
        {
            InitializeComponent();
            var sellinvoce = context.sellinvoces.Where(s => s.BonNumberr == bon).Include(o => o.Orders).FirstOrDefault();
            bon_number.Text=bon.ToString();
            TxtData.Text=sellinvoce.DateTime.ToString();
            totalprice.Text=sellinvoce.TotalPrice.ToString();
            var list = Array.Empty<object>().ToList();
            foreach (var proudet in sellinvoce.Orders)
            {
                var order=context.proudcts.FirstOrDefault(p=>p.Id==proudet.ProudectId);
                int total =(int) order.SellingPrice * proudet.Quanatity;
                list.Add(new { Name=order.Name, Quantity =proudet.Quanatity, SellingPrice =order.SellingPrice, TotalPrice =total});
            }

            printDataGraid.ItemsSource= list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            if (printDlg.ShowDialog() == true)
            {

                printDlg.PrintVisual(griddata, "Bill");

            }
            this.Close();
        }
    }
}
