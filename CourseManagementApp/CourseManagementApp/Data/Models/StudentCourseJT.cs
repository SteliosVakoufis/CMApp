using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagementApp.Data.Models
{
    [Table("StudentsCourses_JT")]
    public class StudentCourseJT
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("Student")]
        [Column("student_id")]
        public int StudentId { get; set; }

        [ForeignKey("Course")]
        [Column("course_id")]
        public int CourseId { get; set; }
    }
}
