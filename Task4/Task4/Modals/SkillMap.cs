using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Task4.Modals
{
    public class SkillMap
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("employee_Id")]
        public int EmployeeId { get; set; }
        public Employee Employees { get; set; }
        [Column("skillId")]
        public int SkillId { get; set; }
        public Skills Skills { get; set; }
    }
}