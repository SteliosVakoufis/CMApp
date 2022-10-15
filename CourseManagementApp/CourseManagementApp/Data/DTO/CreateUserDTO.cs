using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.Data.DTO
{
    public class CreateUserDTO
    {
        [BindProperty]
        [Required]
        [MinLength(4)]
        [MaxLength(16)]
        public string? Username { get; set; }

        [BindProperty]
        [Required]
        [MinLength(3)]
        [MaxLength(55)]
        public string? Firstname { get; set; }

        [BindProperty]
        [Required]
        [MinLength(3)]
        [MaxLength(55)]
        public string? Lastname { get; set; }

        [BindProperty]
        [Required]
        [MinLength(6)]
        [MaxLength(24)]
        public string? Password { get; set; }

        [BindProperty]
        [Required]
        public string? Role { get; set; }

        public CreateUserDTO()
        {
            Username = "";
            Firstname = "";
            Lastname = "";
            Password = "";
            Role = "";
        }
    }
}
