using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WFMProject.Models
{
    public class Skillmap
    {
        public decimal Skillid { get; set; }
        public int Employee_id { get; set; }
        public Employees employees { get; set; }
        public Skills skills { get; set; }
    }
}
