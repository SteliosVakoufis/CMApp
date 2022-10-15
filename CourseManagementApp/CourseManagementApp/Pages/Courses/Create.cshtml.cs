using CourseManagementApp.Data.DTO;
using CourseManagementApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.Pages.Courses
{
    public class CreateModel : PageModel
    {
        [BindProperty, Required]
        public CourseDTO CourseDTO { get; set; }

        ICourseManagementService _service;
        public CreateModel(ICourseManagementService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            if (!User.Identity!.IsAuthenticated) return Redirect("/");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                CourseDTO.Teacher_Id = int.Parse(User.Claims.ToList()[1].Value);
                _service.CreateCourse(CourseDTO);
                return Redirect("/Courses");
            }

            return Page();
        }
    }
}
