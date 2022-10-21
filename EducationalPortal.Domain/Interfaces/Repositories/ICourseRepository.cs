using EducationalPortal.Domain.Entities;

namespace EducationalPortal.Domain.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        Course Create(Course obj);

        Course GetById(int id);

        bool Update(Course obj);

        void Delete(int id);
    }
}
