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
   public class Stor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual List<Categorys> Categories { get; set; }
        [DefaultValue("false")]
        public Boolean IsDelete { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }


    }
}
