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
   public class Recipt
    {
        public int Id { get; set; }
        public int SuppliersId { get; set; }
        public virtual Suppliers supplier { get; set; }
        public float Total { get; set; }
        public virtual List<Proudect> products { get; set; }

        [DefaultValue("false")]
        public Boolean IsDelete { get; set; }
        [DataType(DataType.Date)]

        public DateTime DateTime
        {
            set { dateTime = value; }
            get
            {
                return this.dateTime.HasValue
                   ? this.dateTime.Value
                   : DateTime.Now;
            }

        }

        private DateTime? dateTime = null;


    }
}
