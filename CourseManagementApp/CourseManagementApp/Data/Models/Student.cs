using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagementApp.Data.Models
{
    [Table("Students")]
    public class Student : IRole
    {
        [Key]
        [ForeignKey("User")]
        [Column("student_id")]
        public int Id { get; set; }

        [Column("student_firstname")]
        public string? Firstname { get; set; }

        [Column("student_lastname")]
        public string? Lastname { get; set; }

        public Student() { }

        public Student(string? student_Firstname, string? student_Lastname)
        {
            Firstname = student_Firstname;
            Lastname = student_Lastname;
        }
    }
}
