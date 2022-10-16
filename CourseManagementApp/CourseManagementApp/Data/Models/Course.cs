using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagementApp.Data.Models
{
    [Table("Courses")]
    public class Course
    {
        [Key]
        [Column("course_id")]
        public int Id { get; set; }

        [Column("course_name")]
        public string? Name { get; set; }

        [Column("course_description")]
        public string? Description { get; set; }

        [ForeignKey("Teachers")]
        [Column("teacher_id")]
        public int T_Id { get; set; }

        public Course() { }

        public Course(string? name, string? description, int t_id)
        {
            Name = name;
            Description = description;
            T_Id = t_id;
        }

        public Course(int id, string? name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
