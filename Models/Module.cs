using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnderservedCommunitiesLearningPlatform.Models
{
    public class Module
    {
        [Required]
        [Key]
        public string? ModuleID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Mark { get; set; }

        [Required]
        [ForeignKey("Teacher")]
        public string? TeacherID { get; set; }
        public Teacher? Teacher { get; set; }

        public ICollection<StudentModule> StudentModules { get; set; }

        public Module()
        {
            StudentModules = new List<StudentModule>();
        }

    }
}
