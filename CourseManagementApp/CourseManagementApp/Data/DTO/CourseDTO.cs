using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementApp.Data.DTO
{
    public class CourseDTO
    {
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        [Required]
        [MinLength(3)]
        [MaxLength(55)]
        public string? Name { get; set; }

        [BindProperty]
        [Required]
        [MaxLength(500)]
        public string? Description { get; set; }

        [BindProperty]
        public int T_Id { get; set; }

        public CourseDTO() { }

        public CourseDTO(int id, string? name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
