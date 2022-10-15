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
                    teacher.Teacher_Id = user_id;
                    _context.Teachers.Add(teacher);
                }
                else if (role is Student student)
                {
                    student = (Student)role;
                    student.Student_Id = user_id;
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

                    if (_context.Teachers.Any(x => x.Teacher_Id == result!.Id))
                    {
                        var teacher = _context.Teachers.FirstOrDefault(
                        x => x.Teacher_Id == id);
                        cud.Firstname = teacher?.Teacher_Firstname!;
                        cud.Lastname = teacher?.Teacher_Lastname!;
                        cud.Role = "Teacher";
                    }
                    else
                    {
                        var student = _context.Students.FirstOrDefault(
                        x => x.Student_Id == id);
                        cud.Firstname = student?.Student_Firstname!;
                        cud.Lastname = student?.Student_Lastname!;
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
    }
}
