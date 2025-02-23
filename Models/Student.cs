using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace UnderservedCommunitiesLearningPlatform.Models
{
    public class Student : User
    {
        [Required]
        [Key]
        public string? StudentID { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserID { get; set; }

        public User? User { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string StudentNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Grade { get; set; }
        public ICollection<StudentModule> StudentModules { get; set; }

        public Student(string studentID, string userID, string name, string surname, string studentNumber, string email, string phone, string grade)
        {
            StudentID = studentID;
            UserID = userID;
            Name = name;
            Surname = surname;
            StudentNumber = studentNumber;
            Email = email;
            Phone = phone;
            Grade = grade;
            StudentModules = new List<StudentModule>();
        }

        public Student(string userID)
        {
            UserID = userID;
            StudentID = userID; // Assigning StudentID to UserID
            StudentModules = new List<StudentModule>();
        }
    }

}