using CourseManagementApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagementApp.Pages.Courses.Student
{
    [Authorize(Roles = "Student")]
    public class JoinModel : PageModel
    {
        private readonly ICourseManagementService _service;
        public JoinModel(ICourseManagementService service)
        {
            _service = service;
        }

        public IActionResult OnGet(int c_id, int s_id)
        {
            _service.AddCourseStudentJT(new() { CourseId = c_id, StudentId = s_id });

            return Redirect("/Courses/Student");
        }
    }
}
