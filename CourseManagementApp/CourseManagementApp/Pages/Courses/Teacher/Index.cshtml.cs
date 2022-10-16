using CourseManagementApp.Data.DTO;
using CourseManagementApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.Pages.Courses.Teacher
{
    [Authorize(Roles = "Teacher")]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<CourseDTO> AvailableCourses { get; set; }

        [BindProperty]
        public List<CourseDTO> StudentCourses { get; set; }

        [BindProperty, Required]
        public CourseDTO CourseDTO { get; set; }

        private readonly ICourseManagementService _service;
        public IndexModel(ICourseManagementService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                CourseDTO.T_Id = int.Parse(User.Claims.ToList()[1].Value);
                _service.CreateCourse(CourseDTO);
            }
            return Page();
        }
    }
}
