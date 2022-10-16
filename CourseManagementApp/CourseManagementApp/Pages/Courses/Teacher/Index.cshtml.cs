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
        public List<CourseDTO> TeacherCourses { get; set; }

        [BindProperty, Required]
        public CourseDTO CourseDTO { get; set; }

        private readonly ICourseManagementService _service;
        public IndexModel(ICourseManagementService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            TeacherCourses = _service.GetCoursesByTeacherId(int.Parse(User.Claims.ToList()[1].Value))!;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                CourseDTO.T_Id = int.Parse(User.Claims.ToList()[1].Value);
                if (_service.CreateCourse(CourseDTO))
                {
                    TeacherCourses = _service.GetCoursesByTeacherId(int.Parse(User.Claims.ToList()[1].Value))!;
                }
            }
            return Page();
        }
    }
}
