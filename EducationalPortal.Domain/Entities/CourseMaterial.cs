namespace EducationalPortal.Domain.Entities
{
    public class CourseMaterial : BaseEntity
    {
        public int CourseId { get; set; }

        public int LearnMaterialId { get; set; }

        public Course Course { get; set; }

        public LearnMaterial LearnMaterial { get; set; }
    }
}
