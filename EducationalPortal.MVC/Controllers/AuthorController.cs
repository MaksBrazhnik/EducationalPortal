using AutoMapper;
using EducationalPortal.BLL.Interfaces;
using EducationalPortal.BLL.ServicesImplementation;
using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace EducationalPortal.MVC.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        private readonly IAuthorService authorService;
        private readonly IMapper mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            this.authorService = authorService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(AddAuthorDTO addAuthorDTO)
        {
            if (ModelState.IsValid)
            {
                await authorService.AddAuthorAsync(addAuthorDTO);
                return RedirectToAction("Index", "Book");
            }

            return await AddAuthor();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await authorService.RemoveAuthorAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAuthor(string name)
        {
            return View(await authorService.GetAuthorDTOByNameAsync(name));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAuthor(AuthorDTO authorDTO)
        {
            if (ModelState.IsValid)
            {
                await authorService.UpdateAuthorAsync(authorDTO);
                return RedirectToAction("Index");
            }

            return await UpdateAuthor(authorDTO.Name);
        }
    }
}
