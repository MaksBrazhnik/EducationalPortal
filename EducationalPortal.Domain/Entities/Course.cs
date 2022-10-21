namespace EducationalPortal.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<CourseSkill> CourseSkills { get; set; }

        public List<CourseMaterial> CourseMaterials { get; set; }

        public List<UserCourse> UserCourses { get; set; }
    }
}