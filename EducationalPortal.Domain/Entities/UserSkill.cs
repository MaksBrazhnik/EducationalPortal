namespace EducationalPortal.Domain.Entities
{
    public class UserSkill : BaseEntity
    {
        public int UserId { get; set; }

        public int SkillId { get; set; }

        public int Level { get; set; }

        public User User { get; set; }

        public Skill Skill { get; set; }
    }
}
