using EducationalPortal.Domain.ViewModels;

namespace EducationalPortal.Domain.DTOs
{
    public class ArticleListDTO
    {
        public IEnumerable<ArticleDTO> Articles { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public SortViewModel SortViewModel { get; set; }
    }
}
