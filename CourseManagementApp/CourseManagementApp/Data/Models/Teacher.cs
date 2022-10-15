using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.Data.Models
{
    [Table("Teachers")]
    public class Teacher : IRole
    {
        [Key]
        [ForeignKey("User")]
        [Column("teacher_id")]
        public int Id { get; set; }

        [Column("teacher_firstname")]
        public string? Firstname { get; set; }

        [Column("teacher_lastname")]
        public string? Lastname { get; set; }

        public Teacher() { }

        public Teacher(string? teacher_Firstname, string? teacher_Lastname)
        {
            Firstname = teacher_Firstname;
            Lastname = teacher_Lastname;
        }
    }
}
