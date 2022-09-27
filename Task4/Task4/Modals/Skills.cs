using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Task4.Modals
{
    public class Skills
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("skillId")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }

        public ICollection<SkillMap> SkillMaps { get; set; }

    }
}