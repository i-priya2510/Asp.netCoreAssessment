using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WFMProject.Models
{
    public class Employees
    {
        [Key]
        public int Employee_id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Manager { get; set; }
        public string Wfm_manager { get; set; }
        public string Email { get; set; }
        public string Lockstatus { get; set; }
        public decimal Experience { get; set; }
        public int Profile_id { get; set; }
    }
}
