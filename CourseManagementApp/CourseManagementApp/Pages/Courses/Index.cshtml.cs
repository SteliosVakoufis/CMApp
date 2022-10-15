using CourseManagementApp.Data.DTO;
using CourseManagementApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagementApp.Pages.Courses
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<CourseDTO> Courses { get; set; }

        private readonly ICourseManagementService _service;
        public IndexModel(ICourseManagementService service) {
            _service = service;
        }

        public void OnGet()
        {
            Courses = _service.GetAllCourses();
        }
    }
}
