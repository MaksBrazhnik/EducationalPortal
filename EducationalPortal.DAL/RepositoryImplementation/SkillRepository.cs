using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Interfaces.Repositories;

namespace EducationalPortal.DAL.RepositoryImplementation
{
    public class SkillRepository : ISkillRepository
    {
        public List<Skill> skills = new List<Skill>();

        public SkillRepository(List<Skill> skills)
        {
            this.skills = skills;
        }

        public Skill Create(Skill skill)
        {
            if (skill == null)
            {
                throw new ArgumentNullException("skill is null");
            }

            var previousId = skills.LastOrDefault()?.Id ?? 0;
            skill.Id = previousId++;
            skills.Add(skill);
            return skill;
        }

        public void Delete(int id)
        {
            skills.RemoveAll(p => p.Id == id);
        }

        public Skill GetById(int id)
        {
            return (Skill)skills.Find(p => p.Id == id);
        }

        public bool Update(Skill skill)
        {
            if (skill == null)
            {
                throw new ArgumentNullException("skill");
            }

            int index = skills.FindIndex(p => p.Id == skill.Id);
            if (index == -1)
            {
                return false;
            }

            skills.RemoveAt(index);
            skills.Add(skill);
            return true;
        }
    }
}
