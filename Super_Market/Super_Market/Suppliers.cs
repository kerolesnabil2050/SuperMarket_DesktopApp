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
   public class Suppliers
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }
        public virtual List<Proudect> products { get; set; }
        public virtual List<Recipt> recipts { get; set; }

        [DefaultValue("false")]
        public Boolean IsDelete { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
