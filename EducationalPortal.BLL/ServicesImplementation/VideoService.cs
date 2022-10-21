using AutoMapper;
using EducationalPortal.DAL.RepositoryEFImplementation;
using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Enums;
using EducationalPortal.Domain.Interfaces.RepositoriesEF;
using EducationalPortal.Domain.Interfaces.Services;
using EducationalPortal.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EducationalPortal.BLL.ServicesImplementation
{
    public class VideoService : IVideoService
    {
        public IGenericRepository<Video> videoRepository;
        private static int PAGE_SIZE = 5;
        private readonly IMapper mapper;

        public VideoService(IGenericRepository<Video> videoRepository, IMapper mapper)
        {
            this.videoRepository = videoRepository;
            this.mapper = mapper;
        }

        public async Task<VideoDTO> GetVideoDTOByNameAsync(string name)
        {
            var video = await GetVideoByNameAsync(name);
            return mapper.Map<VideoDTO>(video);
        }

        public async Task<bool> IsCreatedVideo(string name)
        {
            var video = await GetVideoByNameAsync(name);
            return video != null;
        }

        public async Task<VideoDTO> AddVideoAsync(AddVideoDTO addVideoDTO)
        {
            var video = mapper.Map<Video>(addVideoDTO);

            if (await IsCreatedVideo(video.Name))
            {
                return null;
            }

            var id = await videoRepository.CreateAsync(video);
            var createdVideo = await GetVideoByIdAsync(id);
            return mapper.Map<VideoDTO>(createdVideo);
        }

        public async Task RemoveVideoAsync(int id)
        {
            await videoRepository.DeleteAsync(id);
        }

        public async Task<VideoDTO> UpdateVideoAsync(VideoDTO updateVideoDTO)
        {
            var video = await GetVideoByIdAsync(updateVideoDTO.Id);
            var updatedVideo = mapper.Map(updateVideoDTO, video);
            await videoRepository.UpdateAsync(updatedVideo);
            return await GetVideoDTOByNameAsync(updateVideoDTO.Name);
        }

        public async Task<VideoDTO> GetVideoDTOByIdAsync(int id)
        {
            var video = await videoRepository.GetByIdAsync(id);
            return mapper.Map<VideoDTO>(video);
        }

        public async Task<VideoListDTO> GetAllVideosAsync(int page, SortState sortOrder)
        {
            var videos = await GetVideoDTOsAsync();
            switch (sortOrder)
            {
                case SortState.VideoASC:
                    videos = videos.OrderBy(video => video.Name).ToList();
                    break;
                case SortState.VideoDESC:
                    videos = videos.OrderByDescending(video => video.Name).ToList();
                    break;
                default:
                    videos = videos.OrderBy(video => video.Id).ToList();
                    break;
            }

            var count = videos.Count();
            var items = videos.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE).ToList();
            var videoList = new VideoListDTO
            {
                Videos = items,
                SortViewModel = new SortViewModel(sortOrder),
                PageViewModel = new PageViewModel(count, page, PAGE_SIZE)
            };
            return videoList;
        }

        public async Task<IEnumerable<VideoDTO>> GetVideoDTOsAsync()
        {
            var videos = await GetVideosAsync();
            var videoDTOs = mapper.Map<IEnumerable<Video>, IEnumerable<VideoDTO>>(videos);
            return videoDTOs;
        }

        private async Task<Video> GetVideoByIdAsync(int id)
        {
            return await videoRepository.GetByIdAsync(id);
        }

        private async Task<IEnumerable<Video>> GetVideosAsync()
        {
            return await videoRepository.Find().ToListAsync();
        }

        private async Task<Video> GetVideoByNameAsync(string name)
        {
            return await videoRepository.Find().FirstOrDefaultAsync(video => video.Name == name);
        }
    }
}
