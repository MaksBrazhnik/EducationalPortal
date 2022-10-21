using EducationalPortal.Domain.Entities;

namespace EducationalPortal.Domain.Interfaces.Services
{
    public interface ICourseSkillService
    {
        public Task<int> AddCourseSkillAsync(int courseId, int skillId);

        public Task RemoveCourseSkillAsync(int id);

        public Task<CourseSkill> GetCourseSkillByIdAsync(int id);

        public Task<IEnumerable<Skill>> GetSkillsAsync(int courseId);
    }
}
