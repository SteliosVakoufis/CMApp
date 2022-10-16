using CourseManagementApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagementApp.Pages.Courses.Teacher
{
    [Authorize(Roles = "Teacher")]
    public class DeleteModel : PageModel
    {

        private readonly ICourseManagementService _service;
        public DeleteModel(ICourseManagementService service)
        {
            _service = service;
        }

        public IActionResult OnGet(int cId)
        {
            _service.DeleteCourseById(cId);
            return Redirect("/Courses/Teacher");
        }
    }
}
