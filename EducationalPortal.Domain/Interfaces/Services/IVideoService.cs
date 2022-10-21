using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Enums;

namespace EducationalPortal.Domain.Interfaces.Services
{
    public interface IVideoService
    {
        public Task<VideoDTO> GetVideoDTOByNameAsync(string name);

        public Task<bool> IsCreatedVideo(string name);

        public Task<VideoDTO> AddVideoAsync(AddVideoDTO addVideoDTO);

        public Task RemoveVideoAsync(int id);

        public Task<VideoDTO> UpdateVideoAsync(VideoDTO updateVideoDTO);

        public Task<VideoDTO> GetVideoDTOByIdAsync(int id);

        public Task<IEnumerable<VideoDTO>> GetVideoDTOsAsync();

        public Task<VideoListDTO> GetAllVideosAsync(int page, SortState sortOrder);
    }
}
