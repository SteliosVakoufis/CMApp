﻿using CourseManagementApp.DAO;
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

        // Helper Functions
        private Course ComposeCourse(CourseDTO dto)
        {
            return new Course(dto.Name, dto.Description, dto.Teacher_Id);
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
                    Firstname = createUserDTO.Firstname,
                    Lastname = createUserDTO.Lastname,
                };
            }else if (createUserDTO.Role == "teacher")
            {
                role = new Teacher()
                {
                    Firstname = createUserDTO.Firstname,
                    Lastname = createUserDTO.Lastname,
                };
            }
        }
    }
}
