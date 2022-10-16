using CourseManagementApp.Data.DTO;
using CourseManagementApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.Pages.Courses.Teacher
{
    [Authorize(Roles = "Teacher")]
    public class EditModel : PageModel
    {
        [BindProperty, Required]
        public CourseDTO CourseDTO { get; set; }

        private readonly ICourseManagementService _service;
        public EditModel(ICourseManagementService service)
        {
            _service = service;
        }

        public void OnGet(int id)
        {
            CourseDTO = _service.GetCourse(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                //CourseDTO.T_Id = int.Parse(User.Claims.ToList()[1].Value);
                _service.UpdateCourse(CourseDTO);
                return Redirect("/Courses");
            }

            return Page();
        }
    }
}
