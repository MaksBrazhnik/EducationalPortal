using AutoMapper;
using EducationalPortal.BLL.Interfaces;
using EducationalPortal.BLL.ServicesImplementation;
using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Enums;
using EducationalPortal.Domain.Interfaces.Services;
using EducationalPortal.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace EducationalPortal.MVC.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseService courseService;
        private ICourseMaterialService courseMaterialService;
        private ICourseSkillService courseSkillService;
        private IUserCourseService userCourseService;
        private IUserService userService;
        private readonly IMapper mapper;

        public CourseController(ICourseService courseService, IMapper mapper, ICourseMaterialService courseMaterialService, ICourseSkillService courseSkillService, IUserCourseService userCourseService, IUserService userService)
        {
            this.courseService = courseService;
            this.mapper = mapper;
            this.courseMaterialService = courseMaterialService;
            this.courseSkillService = courseSkillService;
            this.userCourseService = userCourseService;
            this.userService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddCourse(string name)
        {
            return View(await courseService.GetCourseDTOByNameAsync(name));
        }

        public async Task<IActionResult> Index(string searchString, int page = 1, SortState sortOrder = SortState.ArticleASC)
        {
            var courses = await courseService.GetAllCoursesAsync(page, sortOrder);
            if (!string.IsNullOrEmpty(searchString))
            {
                courses.Courses = courses.Courses.Where(s => s.Name!.Contains(searchString));
            }

            courses.SearchName = searchString;
            return View(courses);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(AddCourseDTO addCourseDTO)
        {
            if (ModelState.IsValid)
            {
                await courseService.AddCourseAsync(addCourseDTO);
                return RedirectToAction("Index");
            }

            return await AddCourse(addCourseDTO.Name);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await courseService.RemoveCourseAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCourse(int id)
        {
            var courseDTO = await courseService.GetCourseDTOByIdAsync(id);
            return View(courseDTO);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCourse(CourseDTO courseDTO)
        {
            if (ModelState.IsValid)
            {
                await courseService.UpdateCourseAsync(courseDTO);
                return RedirectToAction("Index");
            }

            return await UpdateCourse(courseDTO.Id);
        }

        [HttpGet]
        public async Task<IActionResult> AddCourseMaterial(int id)
        {
            var course = await courseService.GetCourseDTOByIdAsync(id);
            var materials = await courseService.GetMaterialsSelectList();
            return View(new CourseMaterialModel
            {
                CourseName = course.Name,
                CourseId = course.Id,
                MaterialList = materials
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddCourseMaterial(CourseMaterialModel model)
        {
            await courseMaterialService.AddMaterialToCourseAsync(model.CourseId, model.MaterialId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddCourseSkill(int id)
        {
            var course = await courseService.GetCourseDTOByIdAsync(id);
            var skills = await courseService.GetSkillsSelectList();
            return View(new CourseSkillModel
            {
                CourseName = course.Name,
                CourseId = course.Id,
                SkillList = skills
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddCourseSkill(CourseSkillModel model)
        {
            await courseSkillService.AddCourseSkillAsync(model.CourseId, model.SkillId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddCourseToUser(int id)
        {
            var course = await courseService.GetCourseDTOByIdAsync(id);
            var user = await userService.GetUserDTOByEmailAsync(User.Identity.Name);
            await userCourseService.AddUserCourseAsync(course.Id, user.Id);
            return RedirectToAction("Index");
        }
    }
}
