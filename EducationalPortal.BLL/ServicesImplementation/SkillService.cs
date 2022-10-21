using AutoMapper;
using EducationalPortal.DAL.RepositoryEFImplementation;
using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Enums;
using EducationalPortal.Domain.Interfaces.RepositoriesEF;
using EducationalPortal.Domain.Interfaces.Services;
using EducationalPortal.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EducationalPortal.BLL.ServicesImplementation
{
    public class SkillService : ISkillService
    {
        public IGenericRepository<Skill> skillRepository;
        private static int PAGE_SIZE = 5;
        private readonly IMapper mapper;

        public SkillService(IGenericRepository<Skill> skillRepository, IMapper mapper)
        {
            this.skillRepository = skillRepository;
            this.mapper = mapper;
        }

        public async Task<SkillDTO> GetSkillDTOByNameAsync(string name)
        {
            var skill = await GetSkillByNameAsync(name);
            return mapper.Map<SkillDTO>(skill);
        }

        public async Task<bool> IsCreatedSkill(string name)
        {
            var skill = await GetSkillByNameAsync(name);
            return skill != null;
        }

        public async Task<SkillDTO> AddSkillAsync(AddSkillDTO addSkillDTO)
        {
            var skill = mapper.Map<Skill>(addSkillDTO);

            if (await IsCreatedSkill(skill.Name))
            {
                return null;
            }

            var id = await skillRepository.CreateAsync(skill);
            var createdSkill = await GetSkillByIdAsync(id);
            return mapper.Map<SkillDTO>(createdSkill);
        }

        public async Task RemoveSkillAsync(int id)
        {
            await skillRepository.DeleteAsync(id);
        }

        public async Task<SkillDTO> UpdateSkillAsync(SkillDTO updateSkillDTO)
        {
            var skill = await GetSkillByIdAsync(updateSkillDTO.Id);
            var updatedSkill = mapper.Map(updateSkillDTO, skill);
            await skillRepository.UpdateAsync(updatedSkill);
            return await GetSkillDTOByNameAsync(updateSkillDTO.Name);
        }

        public async Task<SkillDTO> GetSkillDTOByIdAsync(int id)
        {
            var skill = await GetSkillByIdAsync(id);
            var skillDTO = mapper.Map<SkillDTO>(skill);
            return skillDTO;
        }

        public async Task<SkillListDTO> GetAllSkillsAsync(int page, SortState sortOrder)
        {
            var skills = await GetSkillDTOsAsync();
            switch (sortOrder)
            {
                case SortState.SkillASC:
                    skills = skills.OrderBy(skill => skill.Name).ToList();
                    break;
                case SortState.SkillDESC:
                    skills = skills.OrderByDescending(skill => skill.Name).ToList();
                    break;
                default:
                    skills = skills.OrderBy(skill => skill.Id).ToList();
                    break;
            }

            var count = skills.Count();
            var items = skills.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE).ToList();
            var skillList = new SkillListDTO
            {
                Skills = items,
                SortViewModel = new SortViewModel(sortOrder),
                PageViewModel = new PageViewModel(count, page, PAGE_SIZE)
            };
            return skillList;
        }

        public async Task<IEnumerable<SkillDTO>> GetSkillDTOsAsync()
        {
            var skills = await GetSkillsAsync();
            var skillDTOs = mapper.Map<IEnumerable<Skill>, IEnumerable<SkillDTO>>(skills);
            return skillDTOs;
        }

        private async Task<Skill> GetSkillByIdAsync(int id)
        {
            return await skillRepository.GetByIdAsync(id);
        }

        private async Task<IEnumerable<Skill>> GetSkillsAsync()
        {
            return await skillRepository.Find().ToListAsync();
        }

        private async Task<Skill> GetSkillByNameAsync(string name)
        {
            return await skillRepository.Find().FirstOrDefaultAsync(skill => skill.Name == name);
        }
    }
}
