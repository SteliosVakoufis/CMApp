using CourseManagementApp.DAO;
using CourseManagementApp.Data;
using CourseManagementApp.Data.DTO;
using CourseManagementApp.Data.Models;

namespace CourseManagementApp.Services
{
    public class CourseManagementServiceImpl : ICourseManagementService
    {
        private ICourseManagementDAO _dao;
        public CourseManagementServiceImpl(ICourseManagementDAO dao)
        {
            _dao = dao;
        }

        public bool CreateUser(CreateUserDTO createUserDTO)
        {
            if (createUserDTO is null) return false;

            try
            {
                ComposeUserRole(createUserDTO, out User? user, out IRole? role);
                return _dao.CreateUser(user!, role!);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ValidateUser(UserDTO userDTO, out CookieUserDTO? cud)
        {
            cud = null;
            if (userDTO.Username is null || userDTO.UserPassword is null) return false;

            try
            {
                return _dao.ValidateUser(ComposeUser(userDTO), out cud);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public bool CreateCourse(CourseDTO courseDTO)
        {
            if (courseDTO is null) return false;
            return _dao.CreateCourse(ComposeCourse(courseDTO));
        }

        public List<CourseDTO>? GetAllCourses()
        {
            try
            {
                return ComposeCourseDTOList(_dao.GetAllCourses());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public List<CourseDTO>? GetCoursesByStudentId(int id)
        {
            try
            {
                return ComposeCourseDTOList(_dao.GetCoursesByStudentId(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public CourseDTO? GetCourse(int id)
        {
            try
            {
                return ComposeCourseDTO(_dao.GetCourseById(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public CourseTeacherDTO? GetCourseTeacher(int id)
        {
            try
            {
                return _dao.GetCourseTeacher(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public bool UpdateCourse(StudentCoursesJTDTO studentCoursesJTDTO)
        {
            try
            {
                return _dao.UpdateCourseStudentJT(ComposeStudentCourseJT(studentCoursesJTDTO));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        // Helper Functions
        private StudentCourseJT ComposeStudentCourseJT(StudentCoursesJTDTO dto)
        {
            return new()
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId,
            };
        }

        private Course ComposeCourse(CourseDTO dto)
        {
            return new(dto.Name, dto.Description, dto.T_Id);
        }

        private CourseDTO? ComposeCourseDTO(Course course_data)
        {
            return new CourseDTO(
                course_data.Id,
                course_data.Name,
                course_data.Description
            );
        }

        private List<CourseDTO> ComposeCourseDTOList(List<Course> data)
        {
            List<CourseDTO> result = new();

            foreach (var item in data)
            {
                result.Add(new(item.Id, item.Name, item.Description));
            }

            return result;
        }

        private User ComposeUser(UserDTO dto)
        {
            return new()
            {
                Id = dto.User_Id,
                Username = dto.Username,
                Password = dto.UserPassword,
            };
        }

        private void ComposeUserRole(CreateUserDTO dto, out User? user, out IRole? role)
        {
            role = null;
            user = new()
            {
                Username = dto.Username,
                Password = dto.Password,
            };
            if (dto.Role == "student")
            {
                role = new Student()
                {
                    Firstname = dto.Firstname,
                    Lastname = dto.Lastname,
                };
            }else if (dto.Role == "teacher")
            {
                role = new Teacher()
                {
                    Firstname = dto.Firstname,
                    Lastname = dto.Lastname,
                };
            }
        }
    }
}
