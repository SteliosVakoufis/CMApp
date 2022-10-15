using CourseManagementApp.Data.DTO;
using CourseManagementApp.Data.Models;

namespace CourseManagementApp.Services
{
    public interface ICourseManagementService
    {
        bool ValidateUser(UserDTO userDTO, out CookieUserDTO? cud);

        bool CreateUser(CreateUserDTO createUserDTO);

        bool CreateCourse(CourseDTO courseDTO);
    }
}
