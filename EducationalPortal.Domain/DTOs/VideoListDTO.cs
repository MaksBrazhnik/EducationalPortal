using EducationalPortal.Domain.ViewModels;

namespace EducationalPortal.Domain.DTOs
{
    public class VideoListDTO
    {
        public IEnumerable<VideoDTO> Videos { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public SortViewModel SortViewModel { get; set; }
    }
}
