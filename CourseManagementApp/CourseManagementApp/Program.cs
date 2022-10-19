using CourseManagementApp.DAO;
using CourseManagementApp.Data;
using CourseManagementApp.Services;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();

            builder.Services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", options =>
            {
                options.Cookie.Name = "CookieAuth";
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/";
            });

            builder.Services.AddScoped<ICourseManagementService, CourseManagementServiceImpl>();
            builder.Services.AddScoped<ICourseManagementDAO, CourseManagementDAOImpl>();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}