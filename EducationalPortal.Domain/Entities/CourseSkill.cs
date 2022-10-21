namespace EducationalPortal.Domain.Entities
{
    public class CourseSkill : BaseEntity
    {
        public int CourseId { get; set; }

        public int SkillId { get; set; }

        public Course Course { get; set; }

        public Skill Skill { get; set; }
    }
}
