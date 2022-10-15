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

        // Helper Functions
        private User ComposeUser(UserDTO dto)
        {
            return new()
            {
                Id = dto.User_Id,
                Username = dto.Username,
                Password = dto.UserPassword,
            };
        }

        private void ComposeUserRole(CreateUserDTO createUserDTO, out User? user, out IRole? role)
        {
            role = null;
            user = new()
            {
                Username = createUserDTO.Username,
                Password = createUserDTO.Password,
            };
            if (createUserDTO.Role == "student")
            {
                role = new Student()
                {
                    Student_Firstname = createUserDTO.Firstname,
                    Student_Lastname = createUserDTO.Lastname,
                };
            }else if (createUserDTO.Role == "teacher")
            {
                role = new Teacher()
                {
                    Teacher_Firstname = createUserDTO.Firstname,
                    Teacher_Lastname = createUserDTO.Lastname,
                };
            }
        }
    }
}
