using AutoMapper;
using EducationalPortal.BLL.Interfaces;
using EducationalPortal.BLL.ServicesImplementation;
using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Enums;
using EducationalPortal.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace EducationalPortal.MVC.Controllers
{
    [Authorize]
    public class SkillController : Controller
    {
        private readonly ISkillService skillService;
        private readonly IMapper mapper;

        public SkillController(ISkillService skillService, IMapper mapper)
        {
            this.skillService = skillService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddSkill(string name)
        {
            return View(await skillService.GetSkillDTOByNameAsync(name));
        }

        public async Task<IActionResult> Index(string searchString, int page = 1, SortState sortOrder = SortState.ArticleASC)
        {
            var skills = await skillService.GetAllSkillsAsync(page, sortOrder);
            if (!string.IsNullOrEmpty(searchString))
            {
                skills.Skills = skills.Skills.Where(s => s.Name!.Contains(searchString));
            }

            return View(skills);
        }

        [HttpPost]
        public async Task<IActionResult> AddSkill(AddSkillDTO addSkillDTO)
        {
            if (ModelState.IsValid)
            {
                await skillService.AddSkillAsync(addSkillDTO);
                return RedirectToAction("Index");
            }

            return await AddSkill(addSkillDTO.Name);
        }

        [HttpPost]
        public async Task<IActionResult> Deleteskill(int id)
        {
            await skillService.RemoveSkillAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSkill(int id)
        {
            return View(await skillService.GetSkillDTOByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSkill(SkillDTO skillDTO)
        {
            if (ModelState.IsValid)
            {
                await skillService.UpdateSkillAsync(skillDTO);
                return RedirectToAction("Index");
            }

            return await UpdateSkill(skillDTO.Id);
        }
    }
}
