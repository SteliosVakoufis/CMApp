using CourseManagementApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagementApp.Pages.Courses.Student
{
    [Authorize(Roles = "Student")]
    public class LeaveModel : PageModel
    {
        private readonly ICourseManagementService _service;
        public LeaveModel(ICourseManagementService service)
        {
            _service = service;
        }

        public IActionResult OnGet(int id)
        {
            _service.DeleteCourseStudentJT(id);

            return Redirect("/Courses/Student");
        }
    }
}
