using CourseManagementApp.Data;
using CourseManagementApp.Data.DTO;
using CourseManagementApp.Data.Models;

namespace CourseManagementApp.DAO
{
    public class CourseManagementDAOImpl : ICourseManagementDAO
    {
        ApplicationDbContext _context;
        public CourseManagementDAOImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateUser(User user, IRole role)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                int user_id = _context.Users.FirstOrDefault(x => x.Username == user.Username)!.Id;
                if (role is Teacher teacher)
                {
                    teacher = (Teacher)role;
                    teacher.Id = user_id;
                    _context.Teachers.Add(teacher);
                }
                else if (role is Student student)
                {
                    student = (Student)role;
                    student.Id = user_id;
                    _context.Students.Add(student);
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool ValidateUser(User user, out CookieUserDTO? cud)
        {
            cud = null;
            try
            {
                var result = _context.Users.FirstOrDefault(
                    x => x.Username == user.Username && x.Password == user.Password);

                if (result is not null)
                {
                    cud = new();
                    int? id = result?.Id;
                    cud.Username = result?.Username!;
                    cud.Id = result?.Id.ToString()!;

                    if (_context.Teachers.Any(x => x.Id == result!.Id))
                    {
                        var teacher = _context.Teachers.FirstOrDefault(
                        x => x.Id == id);
                        cud.Firstname = teacher?.Firstname!;
                        cud.Lastname = teacher?.Lastname!;
                        cud.Role = "Teacher";
                    }
                    else
                    {
                        var student = _context.Students.FirstOrDefault(
                        x => x.Id == id);
                        cud.Firstname = student?.Firstname!;
                        cud.Lastname = student?.Lastname!;
                        cud.Role = "Student";
                    }
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool CreateCourse(Course course)
        {
            try
            {
                _context.Courses.Add(course);
                return _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
