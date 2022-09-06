using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WFMProject.Models
{
    public class Softlock
    {
        public int Employee_id { get; set; }
        public string Manager { get; set; }
        public DateTime ReqDate { get; set; }
        public string Status { get; set; }
        public DateTime Lastupdated { get; set; }        
        [Key]
        public int LockId { get; set; }
        public string RequestMessage { get; set; }
        public string WfmRemark { get; set; }
        public string ManagerStatus { get; set; } = "awaiting_approval";
        public string MgrStatusComment { get; set; }
        public DateTime MgrLastUpdate { get; set; }
        public virtual Employees employees { get; set; }
    }
}
