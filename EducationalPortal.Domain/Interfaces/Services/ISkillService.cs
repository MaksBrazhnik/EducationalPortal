using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Enums;

namespace EducationalPortal.Domain.Interfaces.Services
{
    public interface ISkillService
    {
        public Task<SkillDTO> GetSkillDTOByNameAsync(string name);

        public Task<bool> IsCreatedSkill(string name);

        public Task<SkillDTO> AddSkillAsync(AddSkillDTO addSkillDTO);

        public Task RemoveSkillAsync(int id);

        public Task<SkillDTO> UpdateSkillAsync(SkillDTO updateSkillDTO);

        public Task<SkillDTO> GetSkillDTOByIdAsync(int id);

        public Task<IEnumerable<SkillDTO>> GetSkillDTOsAsync();

        public Task<SkillListDTO> GetAllSkillsAsync(int page, SortState sortOrder);
    }
}
