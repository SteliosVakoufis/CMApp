using CourseManagementApp.Data.DTO;
using CourseManagementApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.Pages.Account
{
    [AllowAnonymous]
    public class CreateAccountModel : PageModel
    {
        [BindProperty, Required]
        public CreateUserDTO CreateUserDTO { get; set; }

        public string errorMsg = "";

        ICourseManagementService _service;
        public CreateAccountModel(ICourseManagementService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            if (User.Identity!.IsAuthenticated) return Redirect("/");

            return Page();
        }

        public IActionResult OnPost()
        {
            Console.WriteLine(ModelState.IsValid);
            if (ModelState.IsValid)
            {

                if (_service.CreateUser(CreateUserDTO))
                {
                    return Redirect("/Account/Login");
                }else
                {
                    errorMsg = "Username already exists!";
                }
            }

            return Page();
        }
    }
}
