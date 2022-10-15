using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.Data.DTO
{
    public class CourseTeacherDTO
    {
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string? Name { get; set; }

        [BindProperty]
        public string? Description { get; set; }

        [BindProperty]
        public int T_Id { get; set; }

        [BindProperty]
        public string? Firstname { get; set; }

        [BindProperty]
        public string? Lastname { get; set; }
    }
}
