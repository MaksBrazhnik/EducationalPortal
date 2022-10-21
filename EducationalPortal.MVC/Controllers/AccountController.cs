using AutoMapper;
using EducationalPortal.BLL.Interfaces;
using EducationalPortal.BLL.ServicesImplementation;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Enums;
using EducationalPortal.Domain.Interfaces.Services;
using EducationalPortal.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EducationalPortal.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly ICourseService courseService;
        private readonly IUserCourseService userCourseService;
        private readonly ICourseMaterialService courseMaterialService;
        private readonly IMapper mapper;

        public AccountController(IUserService userService, IMapper mapper, ICourseService courseService, IUserCourseService userCourseService, ICourseMaterialService courseMaterialService)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.courseService = courseService;
            this.userCourseService = userCourseService;
            this.courseMaterialService = courseMaterialService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userDTO = await userService.GetUserDTOByEmailAsync(User.Identity?.Name);
            return View(mapper.Map<UserUpdateModel>(userDTO));
        }

        [HttpGet]
        public async Task<IActionResult> ShowCourses(int id, int page = 1, SortState sortOrder = SortState.ArticleASC) =>
            View(await userCourseService.GetAllUserCoursesAsync(id, page, sortOrder));

        [HttpGet]
        public async Task<IActionResult> ShowMaterials(int id, int page = 1, SortState sortOrder = SortState.ArticleASC) =>
            View(await courseMaterialService.GetAllCourseMaterialsAsync(id, page, sortOrder));

        [HttpPost]
        public async Task<IActionResult> PassMaterial(int materialId, int courseId)
        {
            await userCourseService.PassMaterial(materialId, courseId, User.Identity?.Name);
            var userId = await userCourseService.GetUserIdByEmail(User.Identity?.Name);
            return RedirectToAction("ShowCourses", new { id = userId});
        }
    }
}
