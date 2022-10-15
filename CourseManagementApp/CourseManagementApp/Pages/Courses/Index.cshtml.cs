using CourseManagementApp.Data.DTO;
using CourseManagementApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagementApp.Pages.Courses
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<CourseDTO> AvailableCourses { get; set; }
        
        [BindProperty]
        public List<CourseDTO> StudentCourses { get; set; }


        private readonly ICourseManagementService _service;
        public IndexModel(ICourseManagementService service) {
            _service = service;
        }

        public void OnGet()
        {
            AvailableCourses = _service.GetAllCourses();
            if(AvailableCourses is null)
                AvailableCourses = new();

            StudentCourses = _service.GetCoursesByStudentId(int.Parse(User.Claims.ToList()[1].Value));
            if (StudentCourses is null)
                StudentCourses = new();

            HashSet<int> ids = new();
            foreach (var item in StudentCourses)
                ids.Add(item.Id);

            for (int i = 0; i < AvailableCourses.Count; i++)
                if (ids.Contains(AvailableCourses[i].Id))
                    AvailableCourses.RemoveRange(i, 1);
        }
    }
}
