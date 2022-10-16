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

        private readonly ICourseManagementService _service;
        public CreateAccountModel(ICourseManagementService service)
        {
            _service = service;
        }

        public IActionResult OnGet(string? username, string? firstname, string? lastname)
        {
            if (User.Identity!.IsAuthenticated) return Redirect("/");

            CreateUserDTO = new();

            if (username is not null)
                CreateUserDTO.Username = username;
            if (firstname is not null)
                CreateUserDTO.Firstname = firstname;
            if (lastname is not null)
                CreateUserDTO.Lastname = lastname;

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
