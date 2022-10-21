using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Interfaces.Repositories;

namespace EducationalPortal.DAL.RepositoryImplementation
{
    public class VideoRepository : IVideoRepository
    {
        public List<Video> videos = new List<Video>();

        public VideoRepository(List<Video> videos)
        {
            this.videos = videos;
        }

        public Video Create(Video video)
        {
            if (video == null)
            {
                throw new ArgumentNullException("video is null");
            }

            var previousId = videos.LastOrDefault()?.Id ?? 0;
            video.Id = previousId++;
            videos.Add(video);
            return video;
        }

        public void Delete(int id)
        {
            videos.RemoveAll(p => p.Id == id);
        }

        public Video GetById(int id)
        {
            return (Video)videos.Find(p => p.Id == id);
        }

        public bool Update(Video video)
        {
            if (video == null)
            {
                throw new ArgumentNullException("video");
            }

            int index = videos.FindIndex(p => p.Id == video.Id);
            if (index == -1)
            {
                return false;
            }

            videos.RemoveAt(index);
            videos.Add(video);
            return true;
        }
    }
}
