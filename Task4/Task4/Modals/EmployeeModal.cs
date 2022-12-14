using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task4.Modals
{
    public class EmployeeModal
    {
        [Key]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public string Manager { get; set; }

        public string Wfm_Manager { get; set; }
        public string Email { get; set; }

        [NotMapped]
        public List<string> Skills { get; set; }
    }
}