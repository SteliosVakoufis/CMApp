using CourseManagementApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagementApp.Pages.Courses
{
    public class JoinModel : PageModel
    {
        private readonly ICourseManagementService _service;
        public JoinModel(ICourseManagementService service)
        {
            _service = service;
        }

        public IActionResult OnGet(int c_id, int s_id)
        {
            if (!User.Identity!.IsAuthenticated) return Redirect("/");

            _service.UpdateCourse(new() { CourseId = c_id, StudentId = s_id});

            return Redirect("/Courses");
        }
    }
}
