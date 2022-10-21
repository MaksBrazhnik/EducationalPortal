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
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IMapper mapper;

        public ArticleController(IArticleService articleService, IMapper mapper)
        {
            this.articleService = articleService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index(string searchString, int page = 1, SortState sortOrder = SortState.ArticleASC)
        {
            var articles = await articleService.GetAllArticlesAsync(page, sortOrder);
            if (!string.IsNullOrEmpty(searchString))
            {
                articles.Articles = articles.Articles.Where(s => s.Name!.Contains(searchString));
            }

            return View(articles);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddArticle(string name)
        {
            return View(await articleService.GetArticleDTOByNameAsync(name));
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle(AddArticleDTO addArticleDTO)
        {
            if (ModelState.IsValid)
            {
                await articleService.AddArticleAsync(addArticleDTO);
                return RedirectToAction("Index");
            }

            return await AddArticle(addArticleDTO.Name);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            await articleService.RemoveArticleAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateArticle (int id)
        {
            return View(await articleService.GetArticleDTOByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateArticle(ArticleDTO articleDTO)
        {
            if (ModelState.IsValid)
            {
                await articleService.UpdateArticleAsync(articleDTO);
                return RedirectToAction("Index");
            }

            return await UpdateArticle(articleDTO.Id);
        }
    }
}
