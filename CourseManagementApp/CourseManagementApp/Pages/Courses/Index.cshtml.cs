using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagementApp.Pages.Courses
{
    [Authorize(Roles = "Student, Teacher")]
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (User.IsInRole("Teacher"))
            {
                return Redirect("/Courses/Teacher");
            } else if (User.IsInRole("Student"))
            {
                return Redirect("/Courses/Student");
            }

            return Page();
        }
    }
}
