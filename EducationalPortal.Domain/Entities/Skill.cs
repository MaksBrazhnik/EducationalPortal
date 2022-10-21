namespace EducationalPortal.Domain.Entities
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }

        public List<CourseSkill> CourseSkills { get; set; }

        public List<UserSkill> UserSkills { get; set; }
    }
}
