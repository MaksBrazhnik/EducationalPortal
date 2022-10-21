using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.ViewModels;

namespace EducationalPortal.Domain.DTOs
{
    public class UserCourseListDTO
    {
        public IEnumerable<UserCourse> UserCourses { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public SortViewModel SortViewModel { get; set; }
    }
}
