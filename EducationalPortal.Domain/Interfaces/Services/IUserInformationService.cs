using EducationalPortal.Domain.Entities;

namespace EducationalPortal.BLL.Interfaces
{
    public interface IUserInformationService
    {
        public Task<List<Course>> ShowCourses(int userId);

        public Task<List<Skill>> ShowSkills(int userId);

        public Task<List<Article>> ShowUserArticles(int userId);

        public Task<List<Book>> ShowUserBooks(int userId);

        public Task<List<Video>> ShowUserVideos(int userId);
    }
}
