namespace CourseManagementApp.Data.DTO
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }

        public TeacherDTO() { }

        public TeacherDTO(int id, string firstname, string lastname)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}
