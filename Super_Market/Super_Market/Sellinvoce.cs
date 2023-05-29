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
   public class Sellinvoce
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BonNumberr { get; set; }
        public int UsersId { get; set; }
        public virtual Users Users { get; set; }
        //public string NameStore { get; set; }
        public virtual List<Order> Orders { get; set; }
        [DataType(DataType.Date)]

        public DateTime DateTime
        {
            set { }
            get
            {
                return this.datetime.HasValue
                   ? this.datetime.Value
                   : DateTime.Now;
            }

        }

        private DateTime? datetime = null;

        public double TotalPrice { get; set; }


        [DefaultValue("false")]
        public Boolean IsDelete { get; set; }
        public double PaidMoney { get; set; }


        public double RemainingMoney { get; set; }
        [DefaultValue("false")]
        public Boolean IsDiscount { get; set; }

    }
}
