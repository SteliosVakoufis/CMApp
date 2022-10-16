using CourseManagementApp.Data.DTO;
using CourseManagementApp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CourseManagementApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty, Required]
        public UserDTO userDTO { get; set; }

        [BindProperty]
        public bool WrongCredentials { get; set; }

        private readonly ICourseManagementService _service;
        public LoginModel(ICourseManagementService service)
        {
            _service = service;
        }

        public IActionResult OnGet(string? username)
        {
            if (User.Identity!.IsAuthenticated)
            {
                return Redirect("/");
            }

            userDTO = new();
            if (username is not null)
                userDTO.Username = username;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (_service.ValidateUser(userDTO, out CookieUserDTO? cud))
                {
                    var claims = new List<Claim> {
                        new Claim(ClaimTypes.Role, cud?.Role!),
                        new Claim(ClaimTypes.Sid, cud?.Id!),
                        new Claim(ClaimTypes.Name, cud?.Firstname!)
                    };

                    var identity = new ClaimsIdentity(claims, "CookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("CookieAuth", claimsPrincipal);

                    return Redirect("/");
                }else
                {
                    WrongCredentials = true;
                }
            }

            return Page();
        }
    }
}
