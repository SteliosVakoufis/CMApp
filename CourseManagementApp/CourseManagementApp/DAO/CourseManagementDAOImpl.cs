using CourseManagementApp.Data;
using CourseManagementApp.Data.DTO;
using CourseManagementApp.Data.Models;
using System.Collections.Generic;

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
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
            }
        }

        public bool CreateCourse(Course course)
        {
            try
            {
                _context.Courses.Add(course);
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Course> GetAllCourses()
        {
            try
            {
                return _context.Courses.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<Course> GetCoursesByStudentId(int id)
        {
            try
            {
                var query =
                    (from course in _context.Courses
                     join sc in _context.StudentsCoursesJT
                        on course.Id equals sc.CourseId
                     where sc.StudentId == id
                     select new { course.Name, course.Description, course.Id}
                     );

                List<Course> result = new();

                foreach (var course in query)
                {
                    result.Add(new()
                    {
                        Id = course.Id,
                        Name = course.Name,
                        Description = course.Description,
                    });
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Course GetCourseById(int id)
        {
            try
            {
                var result = 
                    (from course in _context.Courses
                    where course.Id == id
                    select course).ToList().First();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CourseTeacherDTO GetCourseTeacher(int id)
        {
            try
            {
                var query =
                    (from course in _context.Courses
                    join teacher in _context.Teachers on course.T_Id equals teacher.Id
                    where course.Id == id
                    select new {course.Id, course.Name, course.Description, teacher.Firstname, teacher.Lastname})
                    .FirstOrDefault();

                CourseTeacherDTO result = new()
                {
                    Id = query.Id,
                    Name = query.Name,
                    Description = query.Description,
                    Firstname = query.Firstname,
                    Lastname = query.Lastname
                };

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateCourseStudentJT(StudentCourseJT data)
        {
            try
            {
                bool exists = _context.StudentsCoursesJT.Any(x =>
                    x.StudentId == data.StudentId &&
                    x.CourseId == data.CourseId        
                );

                if (exists) return false; 

                _context.StudentsCoursesJT.Add(data);
                return (_context.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
