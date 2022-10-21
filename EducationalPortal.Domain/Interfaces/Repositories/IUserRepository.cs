using EducationalPortal.Domain.Entities;

namespace EducationalPortal.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User Create(User obj);

        User GetById(int id);

        bool Update(User obj);

        void Delete(int id);
    }
}
