using EducationalPortal.DAL.DBOperation;
using EducationalPortal.DAL.RepositoryEFImplementation;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Interfaces.RepositoriesEF;
using EducationalPortal.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace EducationalPortal.BLL.ServicesImplementation
{
    public class CourseSkillService : ICourseSkillService
    {
        public IGenericRepository<CourseSkill> courseSkillRepository;
        public IGenericRepository<Skill> skillRepository;
        public IGenericRepository<Course> courseRepository;

        public CourseSkillService(IGenericRepository<CourseSkill> courseSkillRepository, IGenericRepository<Skill> skillRepository, IGenericRepository<Course> courseRepository)
        {
            this.courseSkillRepository = courseSkillRepository;
            this.skillRepository = skillRepository;
            this.courseRepository = courseRepository;
        }

        public async Task<int> AddCourseSkillAsync(int courseId, int skillId)
        {
            var courseSkill = await courseSkillRepository.CreateAsync(new CourseSkill
            {
                CourseId = courseId,
                SkillId = skillId
            });
            return courseSkill;
        }

        public async Task RemoveCourseSkillAsync(int id)
        {
            await courseSkillRepository.DeleteAsync(id);
        }

        public async Task<CourseSkill> GetCourseSkillByIdAsync(int id)
        {
            return await courseSkillRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Skill>> GetSkillsAsync(int courseId)
        {
            var course = await courseRepository.Find(include: course => course.Include(course => course.CourseSkills))
                                                                              .FirstOrDefaultAsync(course => course.Id == courseId);
            var skills = new List<Skill>();
            foreach (var courseSkill in course.CourseSkills)
            {
                var skill = await skillRepository.Find().FirstOrDefaultAsync(skill => skill.Id == courseSkill.Id);
                skills.Add(skill);
            }

            return skills;
        }
    }
}
