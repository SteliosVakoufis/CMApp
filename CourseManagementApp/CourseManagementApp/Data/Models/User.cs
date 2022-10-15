using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagementApp.Data.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("User_Id")]
        public int Id { get; set; }

        [Column("Username")]
        public string? Username { get; set; }

        [Column("User_Password")]
        public string? Password { get; set; }
    }
}
