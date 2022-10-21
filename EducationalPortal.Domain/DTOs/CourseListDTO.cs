using EducationalPortal.Domain.ViewModels;

namespace EducationalPortal.Domain.DTOs
{
    public class CourseListDTO
    {
        public IEnumerable<CourseDTO> Courses { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public SortViewModel SortViewModel { get; set; }

        public string SearchName { get; set; } = string.Empty;
    }
}
