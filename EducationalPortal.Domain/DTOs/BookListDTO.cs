using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.ViewModels;

namespace EducationalPortal.Domain.DTOs
{
    public class BookListDTO
    {
        public IEnumerable<BookDTO> Books { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public SortViewModel SortViewModel { get; set; }
    }
}
