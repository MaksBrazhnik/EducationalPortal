using AutoMapper;
using EducationalPortal.BLL.Interfaces;
using EducationalPortal.DAL;
using EducationalPortal.DAL.RepositoryEFImplementation;
using EducationalPortal.DAL.RepositoryImplementation;
using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Enums;
using EducationalPortal.Domain.Interfaces.Repositories;
using EducationalPortal.Domain.Interfaces.RepositoriesEF;
using EducationalPortal.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace EducationalPortal.BLL.ServicesImplementation
{
    public class ArticleService : IArticleService
    {
        public IGenericRepository<Article> articleRepository;
        private const int PAGE_SIZE = 5;
        private readonly IMapper mapper;

        public ArticleService(IGenericRepository<Article> articleRepository, IMapper mapper)
        {
            this.articleRepository = articleRepository;
            this.mapper = mapper;
        }

        public async Task<ArticleDTO> GetArticleDTOByNameAsync(string name)
        {
            var article = await GetArticleByNameAsync(name);
            return mapper.Map<ArticleDTO>(article);
        }

        public async Task<bool> IsCreatedArticle(string name)
        {
            var article = await GetArticleByNameAsync(name);
            return article != null;
        }

        public async Task<ArticleDTO> AddArticleAsync(AddArticleDTO addArticleDTO)
        {
            var article = mapper.Map<Article>(addArticleDTO);

            if (await IsCreatedArticle(article.Name))
            {
                return null;
            }

            var id = await articleRepository.CreateAsync(article);
            var createdArticle = await GetArticleByIdAsync(id);
            return mapper.Map<ArticleDTO>(createdArticle);
        }

        public async Task RemoveArticleAsync(int id)
        {
            await articleRepository.DeleteAsync(id);
        }

        public async Task<ArticleDTO> UpdateArticleAsync(ArticleDTO updateArticleDTO)
        {
            var article = await GetArticleByIdAsync(updateArticleDTO.Id);
            var updatedArticle = mapper.Map(updateArticleDTO, article);
            await articleRepository.UpdateAsync(updatedArticle);
            return await GetArticleDTOByNameAsync(updateArticleDTO.Name);
        }

        public async Task<ArticleDTO> GetArticleDTOByIdAsync(int id)
        {
            var article = await articleRepository.GetByIdAsync(id);
            return mapper.Map<ArticleDTO>(article);
        }

        public async Task<ArticleListDTO> GetAllArticlesAsync(int page, SortState sortOrder)
        {
            var articles = await GetArticlesDTOAsync();
            switch (sortOrder)
            {
                case SortState.ArticleASC:
                    articles = articles.OrderBy(article => article.Name).ToList();
                    break;
                case SortState.ArticleDESC:
                    articles = articles.OrderByDescending(article => article.Name).ToList();
                    break;
                default:
                    articles = articles.OrderBy(article => article.Id).ToList();
                    break;
            }

            var count = articles.Count();
            var items = articles.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE).ToList();
            var articleList = new ArticleListDTO
            {
                Articles = items,
                SortViewModel = new SortViewModel(sortOrder),
                PageViewModel = new PageViewModel(count, page, PAGE_SIZE)
            };
            return articleList;
        }

        public async Task<IEnumerable<ArticleDTO>> GetArticlesDTOAsync()
        {
            var articles = await GetArticlesAsync();
            var articleDTOs = mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(articles);
            return articleDTOs;
        }

        private async Task<Article> GetArticleByIdAsync(int id)
        {
            return await articleRepository.GetByIdAsync(id);
        }

        private async Task<IEnumerable<Article>> GetArticlesAsync()
        {
            return await articleRepository.Find().ToListAsync();
        }

        private async Task<Article> GetArticleByNameAsync(string name)
        {
            return await articleRepository.Find().FirstOrDefaultAsync(article => article.Name == name);
        }
    }
}
