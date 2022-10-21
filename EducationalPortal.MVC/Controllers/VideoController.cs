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
    public class VideoController : Controller
    {
        private readonly IVideoService videoService;
        private readonly IMapper mapper;

        public VideoController(IVideoService videoService, IMapper mapper)
        {
            this.videoService = videoService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddVideo(string name)
        {
            return View(await videoService.GetVideoDTOByNameAsync(name));
        }

        [HttpPost]
        public async Task<IActionResult> AddVideo(AddVideoDTO addVideoDTO)
        {
            if (ModelState.IsValid)
            {
                await videoService.AddVideoAsync(addVideoDTO);
                return RedirectToAction("Index");
            }

            return await AddVideo(addVideoDTO.Name);
        }

        public async Task<IActionResult> Index(string searchString, int page = 1, SortState sortOrder = SortState.ArticleASC)
        {
            var videos = await videoService.GetAllVideosAsync(page, sortOrder);
            if (!string.IsNullOrEmpty(searchString))
            {
                videos.Videos = videos.Videos.Where(s => s.Name!.Contains(searchString));
            }

            return View(videos);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            await videoService.RemoveVideoAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateVideo(int id)
        {
            return View(await videoService.GetVideoDTOByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVideo(VideoDTO videoDTO)
        {
            if (ModelState.IsValid)
            {
                await videoService.UpdateVideoAsync(videoDTO);
                return RedirectToAction("Index");
            }

            return await UpdateVideo(videoDTO.Id);
        }
    }
}
