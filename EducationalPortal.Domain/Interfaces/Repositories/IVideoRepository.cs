using EducationalPortal.Domain.Entities;

namespace EducationalPortal.Domain.Interfaces.Repositories
{
    public interface IVideoRepository
    {
        Video Create(Video obj);

        Video GetById(int id);

        bool Update(Video obj);

        void Delete(int id);
    }
}
