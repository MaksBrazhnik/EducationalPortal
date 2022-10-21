using EducationalPortal.Domain.Entities;

namespace EducationalPortal.Domain.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CourseSkills { get; set; }

        public string CourseMaterials { get; set; }
    }
}
