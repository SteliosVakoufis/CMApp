namespace CourseManagementApp.Data.DTO
{
    public class CookieUserDTO
    {
        public string? Id { get; set; }
        public string? Username { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Role { get; set; }

        public CookieUserDTO()
        {
            Id = "";
            Username = "";
            Firstname = "";
            Lastname = "";
            Role = "";
        }
    }
}
