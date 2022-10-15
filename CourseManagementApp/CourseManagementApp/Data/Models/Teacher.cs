using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.Data.Models
{
    public class Teacher : IRole
    {
        [Key]
        [ForeignKey("User")]
        public int Teacher_Id { get; set; }
        public string? Teacher_Firstname { get; set; }
        public string? Teacher_Lastname { get; set; }

        public Teacher() { }

        public Teacher(string? teacher_Firstname, string? teacher_Lastname)
        {
            Teacher_Firstname = teacher_Firstname;
            Teacher_Lastname = teacher_Lastname;
        }
    }
}
