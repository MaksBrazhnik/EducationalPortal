using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Enums;

namespace EducationalPortal.BLL.Interfaces
{
    public interface IArticleService
    {
        public Task<ArticleDTO> GetArticleDTOByNameAsync(string name);

        public Task<ArticleDTO> AddArticleAsync(AddArticleDTO addArticleDTO);

        public Task<bool> IsCreatedArticle(string name);

        public Task RemoveArticleAsync(int id);

        public Task<ArticleDTO> GetArticleDTOByIdAsync(int id);

        public Task<IEnumerable<ArticleDTO>> GetArticlesDTOAsync();

        public Task<ArticleDTO> UpdateArticleAsync(ArticleDTO updateArticleDTO);

        public Task<ArticleListDTO> GetAllArticlesAsync(int page, SortState sortOrder);
    }
}
