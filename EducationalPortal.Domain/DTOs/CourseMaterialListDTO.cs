using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.ViewModels;

namespace EducationalPortal.Domain.DTOs
{
    public class CourseMaterialListDTO
    {
        public IEnumerable<CourseMaterial> CourseMaterials { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public SortViewModel SortViewModel { get; set; }
    }
}
