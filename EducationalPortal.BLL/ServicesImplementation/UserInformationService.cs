using EducationalPortal.BLL.Interfaces;
using EducationalPortal.DAL.DBOperation;
using EducationalPortal.DAL.RepositoryEFImplementation;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Interfaces.RepositoriesEF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EducationalPortal.BLL.ServicesImplementation
{
    public class UserInformationService : IUserInformationService
    {
        private IGenericRepository<User> userRepository;
        private IGenericRepository<Course> courseRepository;
        private IGenericRepository<Skill> skillRepository;
        private IGenericRepository<Article> articleRepository;
        private IGenericRepository<Book> bookRepository;
        private IGenericRepository<Video> videoRepository;
        private IGenericRepository<UserMaterial> userMaterialRepository;
        private IGenericRepository<Author> authorRepository;
        private IGenericRepository<UserCourse> userCourseRepository;

        public UserInformationService(IGenericRepository<User> userRepository, IGenericRepository<Course> courseRepository, IGenericRepository<Skill> skillRepository, IGenericRepository<Article> articleRepository, IGenericRepository<Book> bookRepository, IGenericRepository<Video> videoRepository, IGenericRepository<UserMaterial> userMaterialRepository, IGenericRepository<Author> authorRepository, IGenericRepository<UserCourse> userCourseRepository)
        {
            this.userRepository = userRepository;
            this.courseRepository = courseRepository;
            this.skillRepository = skillRepository;
            this.articleRepository = articleRepository;
            this.bookRepository = bookRepository;
            this.videoRepository = videoRepository;
            this.userMaterialRepository = userMaterialRepository;
            this.authorRepository = authorRepository;
            this.userCourseRepository = userCourseRepository;
        }

        public async Task<List<Course>> ShowCourses(int userId)
        {
            var user = await userRepository.Find(include: user => user.Include(course => course.UserСourses)).FirstOrDefaultAsync(user => user.Id == userId);
            var courses = new List<Course>();
            foreach (var userCourse in user.UserСourses)
            {
                var course = await courseRepository.Find().FirstOrDefaultAsync(course => course.Id == userCourse.CourseId);
                courses.Add(course);
            }

            return courses;
        }

        public async Task<List<Skill>> ShowSkills(int userId)
        {
            var user = await userRepository.Find(include: user => user.Include(skill => skill.UserSkills)).FirstOrDefaultAsync(user => user.Id == userId);
            var skills = new List<Skill>();
            foreach (var userSkill in user.UserSkills)
            {
                var skill = await skillRepository.Find().FirstOrDefaultAsync(skill => skill.Id == userSkill.SkillId);
                skills.Add(skill);
            }

            return skills;
        }

        public async Task<List<Article>> ShowUserArticles(int userId)
        {
            var user = await userRepository.Find(include: user => user.Include(material => material.UserMaterials)).FirstOrDefaultAsync(user => user.Id == userId);
            var articles = new List<Article>();
            foreach (var userMaterial in user.UserMaterials)
            {
                var article = await articleRepository.Find().FirstOrDefaultAsync(article => article.Id == userMaterial.LearnMaterialId);
                articles.Add(article);
            }

            return articles;
        }

        public async Task<List<Book>> ShowUserBooks(int userId)
        {
            var user = await userRepository.Find(include: user => user.Include(material => material.UserMaterials)).FirstOrDefaultAsync(user => user.Id == userId);
            var books = new List<Book>();
            foreach (var userMaterial in user.UserMaterials)
            {
                var book = await bookRepository.Find(include: book => book.Include(bookAuthor => bookAuthor.BookAuthors))
                                               .FirstOrDefaultAsync(book => book.Id == userMaterial.LearnMaterialId);
                books.Add(book);
                foreach (var bookAuthors in book.BookAuthors)
                {
                    var author = await authorRepository.Find().FirstOrDefaultAsync(author => author.Id == bookAuthors.AuthorId);
                }
            }

            return books;
        }

        public async Task<List<Video>> ShowUserVideos(int userId)
        {
            var user = await userRepository.Find(include: user => user.Include(material => material.UserMaterials)).FirstOrDefaultAsync(user => user.Id == userId);
            var videos = new List<Video>();
            foreach (var userMaterial in user.UserMaterials)
            {
                var video = await videoRepository.Find().FirstOrDefaultAsync(video => video.Id == userMaterial.LearnMaterialId);
                videos.Add(video);
            }

            return videos;
        }
    }
}
