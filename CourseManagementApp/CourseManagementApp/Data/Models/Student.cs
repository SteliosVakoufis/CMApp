using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagementApp.Data.Models
{
    public class Student : IRole
    {
        [Key]
        [ForeignKey("User")]
        public int Student_Id { get; set; }
        public string? Student_Firstname { get; set; }
        public string? Student_Lastname { get; set; }

        public Student() { }

        public Student(string? student_Firstname, string? student_Lastname)
        {
            Student_Firstname = student_Firstname;
            Student_Lastname = student_Lastname;
        }
    }
}
