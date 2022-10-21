using EducationalPortal.Domain.Entities;

namespace EducationalPortal.Domain.Interfaces.Repositories
{
    public interface IArticleRepository
    {
        Article Create(Article obj);

        Article GetById(int id);

        bool Update(Article obj);

        void Delete(int id);
    }
}
