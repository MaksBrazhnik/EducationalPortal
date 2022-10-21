namespace EducationalPortal.Domain.Entities
{
    public class UserMaterial : BaseEntity
    {
        public int UserId { get; set; }

        public int LearnMaterialId { get; set; }

        public bool IsPassed { get; set; }

        public User User { get; set; }

        public LearnMaterial LearnMaterial { get; set; }
    }
}
