using EducationalPortal.BLL.Interfaces;
using EducationalPortal.BLL.ServicesImplementation;
using EducationalPortal.DAL.DBOperation;
using EducationalPortal.DAL.RepositoryEFImplementation;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Interfaces.RepositoriesEF;
using EducationalPortal.Domain.Interfaces.Services;
using EducationalPortal.MVC.Mapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Build.Logging;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace EducationalPortal.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            string connection = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<EducationalPortalContext>(options => options.UseSqlServer(connection));

            builder.Services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();

            builder.Services.AddScoped<IGenericRepository<LearnMaterial>, GenericRepository<LearnMaterial>>();

            builder.Services.AddScoped<IGenericRepository<Article>, GenericRepository<Article>>();

            builder.Services.AddScoped<IGenericRepository<Book>, GenericRepository<Book>>();

            builder.Services.AddScoped<IGenericRepository<Course>, GenericRepository<Course>>();

            builder.Services.AddScoped<IGenericRepository<Video>, GenericRepository<Video>>();

            builder.Services.AddScoped<IGenericRepository<Skill>, GenericRepository<Skill>>();

            builder.Services.AddScoped<IGenericRepository<Author>, GenericRepository<Author>>();

            builder.Services.AddScoped<IGenericRepository<BookAuthor>, GenericRepository<BookAuthor>>();

            builder.Services.AddScoped<IGenericRepository<CourseMaterial>, GenericRepository<CourseMaterial>>();

            builder.Services.AddScoped<IGenericRepository<CourseSkill>, GenericRepository<CourseSkill>>();

            builder.Services.AddScoped<IGenericRepository<UserCourse>, GenericRepository<UserCourse>>();

            builder.Services.AddScoped<IGenericRepository<UserSkill>, GenericRepository<UserSkill>>();

            builder.Services.AddScoped<IGenericRepository<UserMaterial>, GenericRepository<UserMaterial>>();

            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<IArticleService, ArticleService>();

            builder.Services.AddScoped<IBookService, BookService>();

            builder.Services.AddScoped<ICourseService, CourseService>();

            builder.Services.AddScoped<IVideoService, VideoService>();

            builder.Services.AddScoped<ISkillService, SkillService>();

            builder.Services.AddScoped<IAuthorService, AuthorService>();

            builder.Services.AddScoped<IBookAuthorService, BookAuthorService>();

            builder.Services.AddScoped<ICourseMaterialService, CourseMaterialService>();

            builder.Services.AddScoped<ICourseSkillService, CourseSkillService>();

            builder.Services.AddScoped<IUserCourseService, UserCourseService>();

            builder.Services.AddScoped<IUserInformationService, UserInformationService>();

            builder.Services.AddAutoMapper(typeof(MapperProfile));

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/User/Login");
                    options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/User/Login");
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRequestLocalization();

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=RegisterUser}/{id?}");

            app.Run();
        }
    }
}
