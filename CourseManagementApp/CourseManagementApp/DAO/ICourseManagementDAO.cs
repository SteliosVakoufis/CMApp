using CourseManagementApp.Data.DTO;
using CourseManagementApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementApp.DAO
{
    public interface ICourseManagementDAO
    {
        bool ValidateUser(User user, out CookieUserDTO? cud);

        bool CreateUser(User user, IRole role);

        bool CreateCourse(Course course);

        List<Course> GetAllCourses();

        Course GetCourse(int id);

        CourseTeacherDTO GetCourseTeacher(int id);

        //DbSet<Student> GetStudents();

    }
}
