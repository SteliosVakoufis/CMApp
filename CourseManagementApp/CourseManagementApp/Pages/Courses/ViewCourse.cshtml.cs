using CourseManagementApp.Data.DTO;
using CourseManagementApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagementApp.Pages.Courses
{
    [Authorize(Roles = "Student, Teacher")]
    public class ViewCourseModel : PageModel
    {
        [BindProperty]
        public CourseTeacherDTO CourseTeacher { get; set; }

        private readonly ICourseManagementService _service;
        public ViewCourseModel(ICourseManagementService service)
        {
            _service = service;
        }

        public IActionResult OnGet(int id)
        {
            CourseTeacher = _service.GetCourseTeacher(id)!;
            if(CourseTeacher == null) return NotFound();
            return Page();
        }
    }
}
