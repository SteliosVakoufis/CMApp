using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.Data.DTO
{
    public class UserDTO
    {
        public int User_Id { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(16)]
        public string? Username { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(24)]
        public string? UserPassword { get; set; }
    }
}
