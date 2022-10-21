using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Interfaces.Repositories;

namespace EducationalPortal.DAL.RepositoryImplementation
{
    public class ArticleRepository : IArticleRepository
    {
        public List<Article> articles = new List<Article>();

        public ArticleRepository(List<Article> articles)
        {
            this.articles = articles;
        }

        public Article Create(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException("Article is null");
            }

            var previousId = articles.LastOrDefault()?.Id ?? 0;
            article.Id = previousId++;
            articles.Add(article);
            return article;
        }

        public void Delete(int id)
        {
            articles.RemoveAll(p => p.Id == id);
        }

        public Article GetById(int id)
        {
            return (Article)articles.Find(p => p.Id == id);
        }

        public bool Update(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException("article");
            }

            int index = articles.FindIndex(p => p.Id == article.Id);
            if (index == -1)
            {
                return false;
            }

            articles.RemoveAt(index);
            articles.Add(article);
            return true;
        }
    }
}
