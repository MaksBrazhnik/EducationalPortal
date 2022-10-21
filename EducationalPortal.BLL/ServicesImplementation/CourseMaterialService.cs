using EducationalPortal.DAL.DBOperation;
using EducationalPortal.DAL.RepositoryEFImplementation;
using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Enums;
using EducationalPortal.Domain.Interfaces.RepositoriesEF;
using EducationalPortal.Domain.Interfaces.Services;
using EducationalPortal.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EducationalPortal.BLL.ServicesImplementation
{
    public class CourseMaterialService : ICourseMaterialService
    {
        private static int PAGE_SIZE = 5;
        private IGenericRepository<CourseMaterial> courseMaterialRepository;
        private IGenericRepository<Course> courseRepository;
        private IGenericRepository<LearnMaterial> learnMaterialRepository;

        public CourseMaterialService(IGenericRepository<CourseMaterial> courseMaterialRepository, IGenericRepository<Course> courseRepository, IGenericRepository<LearnMaterial> learnMaterialRepository)
        {
            this.courseMaterialRepository = courseMaterialRepository;
            this.learnMaterialRepository = learnMaterialRepository;
            this.courseRepository = courseRepository;
        }

        public async Task RemoveCourseMaterialAsync(int id)
        {
            await courseMaterialRepository.DeleteAsync(id);
        }

        public async Task<CourseMaterial> GetCourseMaterialByIdAsync(int id)
        {
            return await courseMaterialRepository.GetByIdAsync(id);
        }

        public async Task<int> AddMaterialToCourseAsync(int courseId, int materialId)
        {
            var courseMaterial = await courseMaterialRepository.CreateAsync(new CourseMaterial
            {
                CourseId = courseId,
                LearnMaterialId = materialId
            });
            return courseMaterial;
        }

        public async Task<IEnumerable<LearnMaterial>> GetMaterialsAsync(int courseId)
        {
            var course = await courseRepository.Find(include: course => course
                                                       .Include(course => course.CourseMaterials))
                                                       .FirstOrDefaultAsync(course => course.Id == courseId);
            var learnMaterials = new List<LearnMaterial>();
            foreach (var courseMaterial in course.CourseMaterials)
            {
                var learnMaterial = await learnMaterialRepository.Find().FirstOrDefaultAsync(material => material.Id == courseMaterial.Id);
                learnMaterials.Add(learnMaterial);
            }

            return learnMaterials;
        }

        public async Task<CourseMaterialListDTO> GetAllCourseMaterialsAsync(int courseId, int page, SortState sortOrder)
        {
            var courseMaterials = await GetCourseMaterials(courseId);
            switch (sortOrder)
            {
                case SortState.CourseMaterialASC:
                    courseMaterials = courseMaterials.OrderBy(courseMaterial => courseMaterial.Id).ToList();
                    break;
                case SortState.CourseMaterialDESC:
                    courseMaterials = courseMaterials.OrderByDescending(courseMaterial => courseMaterial.Id).ToList();
                    break;
                default:
                    courseMaterials = courseMaterials.OrderBy(courseMaterial => courseMaterial.Id).ToList();
                    break;
            }

            var count = courseMaterials.Count();
            var items = courseMaterials.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE).ToList();
            var courseMaterialList = new CourseMaterialListDTO
            {
                CourseMaterials = items,
                SortViewModel = new SortViewModel(sortOrder),
                PageViewModel = new PageViewModel(count, page, PAGE_SIZE)
            };
            return courseMaterialList;
        }

        private async Task<List<CourseMaterial>> GetCourseMaterials(int id)
        {
            var course = await courseRepository.Find(include: course => course.Include(course => course.CourseMaterials)
                                                                        .ThenInclude(courseMaterial => courseMaterial.LearnMaterial)
                                                                        .ThenInclude(material => material.UserMaterials)
                                                                        .ThenInclude(userMaterial => userMaterial.User)
                                                                        .Include(course => course.CourseSkills)
                                                                        .ThenInclude(courseSkill => courseSkill.Skill))
                                                                        .FirstOrDefaultAsync(course => course.Id == id);
            return course.CourseMaterials;
        }
    }
}
