using EducationalPortal.Domain.Entities;

namespace EducationalPortal.Domain.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Book Create(Book obj);

        Book GetById(int id);

        bool Update(Book obj);

        void Delete(int id);
    }
}
