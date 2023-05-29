using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market
{
    [Flags]
    public enum position
    {
        Casher,
        Admin,
    }
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public double Salary { get; set; }
        public position Pos { get; set; }
        public virtual List<Sellinvoce> Sellinvos { get; set; }
        [DefaultValue("false")]
        public Boolean IsDelete { get; set; }
    }
}
