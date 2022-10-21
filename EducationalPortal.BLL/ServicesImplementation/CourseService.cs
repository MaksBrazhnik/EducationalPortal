using AutoMapper;
using EducationalPortal.BLL.Interfaces;
using EducationalPortal.DAL.RepositoryEFImplementation;
using EducationalPortal.DAL.RepositoryImplementation;
using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Enums;
using EducationalPortal.Domain.Interfaces.Repositories;
using EducationalPortal.Domain.Interfaces.RepositoriesEF;
using EducationalPortal.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace EducationalPortal.BLL.ServicesImplementation
{
    public class CourseService : ICourseService
    {
        private static int PAGE_SIZE = 5;
        private IGenericRepository<Course> courseRepository;
        private IGenericRepository<LearnMaterial> learnMaterialRepository;
        private IGenericRepository<Skill> skillRepository;
        private readonly IMapper mapper;

        public CourseService(IGenericRepository<Course> courseRepository, IMapper mapper, IGenericRepository<LearnMaterial> learnMaterialRepository, IGenericRepository<Skill> skillRepository)
        {
            this.courseRepository = courseRepository;
            this.mapper = mapper;
            this.learnMaterialRepository = learnMaterialRepository;
            this.skillRepository = skillRepository;
        }

        public async Task<CourseDTO> GetCourseDTOByNameAsync(string name)
        {
            var course = await GetCourseByNameAsync(name);
            return mapper.Map<CourseDTO>(course);
        }

        public async Task<CourseDTO> GetCourseDTOByIdAsync(int id)
        {
            var course = await GetCourseByIdAsync(id);
            return mapper.Map<CourseDTO>(course);
        }

        public async Task<bool> IsCreatedCourse(string name)
        {
            var course = await GetCourseByNameAsync(name);
            return course != null;
        }

        public async Task<CourseDTO> AddCourseAsync(AddCourseDTO addCourseDTO)
        {
            var course = mapper.Map<Course>(addCourseDTO);

            if (await IsCreatedCourse(course.Name))
            {
                return null;
            }

            var id = await courseRepository.CreateAsync(course);
            var createdCourse = await GetCourseByIdAsync(id);
            return mapper.Map<CourseDTO>(createdCourse);
        }

        public async Task RemoveCourseAsync(int id)
        {
            await courseRepository.DeleteAsync(id);
        }

        public async Task<CourseDTO> UpdateCourseAsync(CourseDTO updateCourseDTO)
        {
            var course = await GetCourseByIdAsync(updateCourseDTO.Id);
            var updatedCourse = mapper.Map(updateCourseDTO, course);
            await courseRepository.UpdateAsync(updatedCourse);
            return await GetCourseDTOByNameAsync(updateCourseDTO.Name);
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await courseRepository.GetByIdAsync(id);
        }

        public async Task<List<SelectListItem>> GetMaterialsSelectList()
        {
            return await learnMaterialRepository.Find()
                                                .Select(material => new SelectListItem
                                                {
                                                    Text = $"{material.Name} ({material.LearnMaterialsType.ToString()})",
                                                    Value = material.Id.ToString()
                                                }).ToListAsync();
        }

        public async Task<List<SelectListItem>> GetSkillsSelectList()
        {
            return await skillRepository.Find()
                                                .Select(skill => new SelectListItem
                                                {
                                                    Text = skill.Name,
                                                    Value = skill.Id.ToString()
                                                }).ToListAsync();
        }

        public async Task<CourseListDTO> GetAllCoursesAsync(int page, SortState sortOrder)
        {
            var courses = await GetCoursesDTOAsync();
            switch (sortOrder)
            {
                case SortState.CourseASC:
                    courses = courses.OrderBy(course => course.Name).ToList();
                    break;
                case SortState.CourseDESC:
                    courses = courses.OrderByDescending(course => course.Name).ToList();
                    break;
                default:
                    courses = courses.OrderBy(course => course.Id).ToList();
                    break;
            }

            var count = courses.Count();
            var items = courses.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE).ToList();
            var courseList = new CourseListDTO
            {
                Courses = items,
                SortViewModel = new SortViewModel(sortOrder),
                PageViewModel = new PageViewModel(count, page, PAGE_SIZE)
            };
            return courseList;
        }

        public async Task<IEnumerable<CourseDTO>> GetCoursesDTOAsync()
        {
            var courses = await GetCoursesAsync();
            var courseDTOs = new List<CourseDTO>();
            courses.ForEach(course => courseDTOs.Add(new CourseDTO()
            {
                CourseMaterials = string.Join(", ", course.CourseMaterials.Select(courseMaterial => $"{courseMaterial.LearnMaterial.Name} ({courseMaterial.LearnMaterial.LearnMaterialsType})")),
                CourseSkills = string.Join(", ", course.CourseSkills.Select(courseSkill => courseSkill.Skill.Name)),
                Id = course.Id,
                Name = course.Name,
                Description = course.Description
            }));
            return courseDTOs;
        }

        public async Task<Course> GetFilledCourseByIdAsync(int id)
        {
            return await courseRepository.Find(include: course => course.Include(course => course.CourseMaterials)
                                                                        .ThenInclude(courseMaterial => courseMaterial.LearnMaterial)
                                                                        .ThenInclude(material => material.UserMaterials)
                                                                        .ThenInclude(userMaterial => userMaterial.User)
                                                                        .Include(course => course.CourseSkills)
                                                                        .ThenInclude(courseSkill => courseSkill.Skill))
                                                                        .FirstOrDefaultAsync(course => course.Id == id);
        }

        public async Task<Course> GetCourseByNameAsync(string name)
        {
            return await courseRepository.Find().FirstOrDefaultAsync(course => course.Name == name);
        }

        private async Task<List<Course>> GetCoursesAsync()
        {
            return await courseRepository.Find(include: course => course.Include(course => course.CourseMaterials)
                                                                        .ThenInclude(courseMaterials => courseMaterials.LearnMaterial)
                                                                        .Include(course => course.CourseSkills)
                                                                        .ThenInclude(courseSkill => courseSkill.Skill)).ToListAsync();
        }
    }
}
