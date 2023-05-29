using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market
{
   public class Proudect
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double SellingPrice { get; set; }
        public double PurchasingPrice { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }
        public int CategorysId { get; set; }

        public virtual Categorys category { get; set; }
        public int Suppliersid { get; set; }
        public virtual Suppliers supplier { get; set; }
        public virtual List<Order> orders { get; set; }
        [DefaultValue("false")]
        public Boolean IsDelete { get; set; }
        public override string ToString()
        {
            return $"{Name}";

        }

    }
}
