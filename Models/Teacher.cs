using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UnderservedCommunitiesLearningPlatform.Models
{
    public class Teacher : User
    {

        [Required]
        [Key]
        public string? TeacherID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserID { get; set; }

        public User User { get; set; }

        public ICollection<Module> Modules { get; set; }

        public Teacher()
        {
            Modules = new List<Module>();
        }

        public Teacher(string teacherID, string userID, string name, string surname, string email, string phone)
        {
            TeacherID = teacherID;
            UserID = userID;
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
            Modules = new List<Module>();
        }

        public Teacher(string userID, string name, string surname, string email, string phone)
        {
            UserID = userID;
            TeacherID = userID;
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
            Modules = new List<Module>();
        }
    }
}