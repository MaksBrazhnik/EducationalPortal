using AutoMapper;
using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Entities;
using EducationalPortal.MVC.Models;

namespace EducationalPortal.MVC.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserRegistrationDTO>().ReverseMap();
            CreateMap<UserRegistrationDTO, UserRegistrationModel>().ReverseMap();
            CreateMap<UserDTO, UserUpdateModel>().ReverseMap();
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Course, AddCourseDTO>().ReverseMap();
            CreateMap<AddCourseDTO, AddCourseModel>().ReverseMap();
            CreateMap<CourseDTO, CourseModel>().ReverseMap();
            CreateMap<Article, ArticleDTO>().ReverseMap();
            CreateMap<Article, AddArticleDTO>().ReverseMap();
            CreateMap<AddArticleDTO, AddArticleModel>().ReverseMap();
            CreateMap<ArticleDTO, ArticleModel>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, AddBookDTO>().ReverseMap();
            CreateMap<AddBookDTO, AddBookModel>().ReverseMap();
            CreateMap<BookDTO, BookModel>().ReverseMap();
            CreateMap<Skill, SkillDTO>().ReverseMap();
            CreateMap<Skill, AddSkillDTO>().ReverseMap();
            CreateMap<AddSkillDTO, AddSkillModel>().ReverseMap();
            CreateMap<SkillDTO, SkillModel>().ReverseMap();
            CreateMap<Video, VideoDTO>().ReverseMap();
            CreateMap<Video, AddVideoDTO>().ReverseMap();
            CreateMap<AddVideoDTO, AddVideoModel>().ReverseMap();
            CreateMap<VideoDTO, VideoModel>().ReverseMap();
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Author, AddAuthorDTO>().ReverseMap();
            CreateMap<AddAuthorDTO, AddAuthorModel>().ReverseMap();
            CreateMap<AuthorDTO, AuthorModel>().ReverseMap();
        }
    }
}
