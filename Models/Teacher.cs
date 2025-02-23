using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace UnderservedCommunitiesLearningPlatform.Models
{
    public class Teacher : User
    {
        [Required]
        public string? TeacherID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

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
            TeacherID = userID; // Assigning TeacherID to UserID
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
            Modules = new List<Module>();
        }
    }
}








