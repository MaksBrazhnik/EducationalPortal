using EducationalPortal.Domain.Entities;

namespace EducationalPortal.Domain.Interfaces.Repositories
{
    public interface ISkillRepository
    {
        Skill Create(Skill obj);

        Skill GetById(int id);

        bool Update(Skill obj);

        void Delete(int id);
    }
}
