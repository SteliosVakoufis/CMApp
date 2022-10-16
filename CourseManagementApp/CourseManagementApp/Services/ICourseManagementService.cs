using CourseManagementApp.Data.DTO;
using CourseManagementApp.Data.Models;

namespace CourseManagementApp.Services
{
    public interface ICourseManagementService
    {
        bool ValidateUser(UserDTO userDTO, out CookieUserDTO? cud);

        bool CreateUser(CreateUserDTO createUserDTO);

        bool CreateCourse(CourseDTO courseDTO);
        
        List<CourseDTO>? GetAllCourses();

        List<CourseDTO>? GetCoursesByStudentId(int id);

        CourseDTO? GetCourse(int id);

        CourseTeacherDTO? GetCourseTeacher(int id);

        bool UpdateCourseStudentJT(StudentCoursesJTDTO studentCoursesJTDTO);

        bool DeleteCourseStudentJT(int id);
    }
}
