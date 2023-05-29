using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market
{
    public class Order
    {
        public int Id { get; set; }
        public int Quanatity { get; set; }
        public int ProudectId { get; set; }
        public virtual Proudect Proudect { get; set; }
        public int SellinvoceId { get; set; }
        public virtual Sellinvoce Sellinvoce { get; set; }
        [DefaultValue("false")]
        public Boolean IsDelete { get; set; }

       


    }
}
