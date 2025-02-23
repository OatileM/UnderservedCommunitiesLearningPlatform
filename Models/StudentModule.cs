using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnderservedCommunitiesLearningPlatform.Models
{
    public class StudentModule
    {

        [Required]
        [ForeignKey("Student")]
        public string StudentID { get; set; }
        public Student Student { get; set; }

        [Required]
        [ForeignKey("Module")]
        public string ModuleID { get; set; }
        public Module Module { get; set; }

        public string Mark { get; set; }
    }
}
