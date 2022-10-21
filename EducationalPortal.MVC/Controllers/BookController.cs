using AutoMapper;
using EducationalPortal.BLL.Interfaces;
using EducationalPortal.BLL.ServicesImplementation;
using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Enums;
using EducationalPortal.Domain.Interfaces.Services;
using EducationalPortal.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace EducationalPortal.MVC.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly IBookAuthorService bookAuthorService;
        private readonly IMapper mapper;

        public BookController(IBookService bookService, IMapper mapper, IBookAuthorService bookAuthorService)
        {
            this.bookService = bookService;
            this.mapper = mapper;
            this.bookAuthorService = bookAuthorService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddBook()
        {
            return View();
        }

        public async Task<IActionResult> Index(string searchString, int page = 1, SortState sortOrder = SortState.ArticleASC)
        {
            var books = await bookService.GetAllBooksAsync(page, sortOrder);
            if (!string.IsNullOrEmpty(searchString))
            {
                books.Books = books.Books.Where(s => s.Name!.Contains(searchString));
            }

            return View(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookDTO addBookDTO)
        {
            if (ModelState.IsValid)
            {
                await bookService.AddBookAsync(addBookDTO);
                return RedirectToAction("Index");
            }

            return await AddBook();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await bookService.RemoveBookAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBook(int id)
        {
            return View(await bookService.GetBookDTOByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(BookDTO bookDTO)
        {
            if (ModelState.IsValid)
            {
                await bookService.UpdateBookAsync(bookDTO);
                return RedirectToAction("Index");
            }

            return await UpdateBook(bookDTO.Id);
        }

        [HttpGet]
        public async Task<IActionResult> AddBookAuthor(int id)
        {
            var book = await bookService.GetBookDTOByIdAsync(id);
            var authors = await bookService.GetAuthorsSelectList();
            return View(new BookAuthorModel
            {
                BookName = book.Name,
                BookId = book.Id,
                AuthorsList = authors
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddBookAuthor(BookAuthorModel bookAuthorModel)
        {
            await bookAuthorService.AddBookAuthorAsync(bookAuthorModel.BookId, bookAuthorModel.AuthorId);
            return RedirectToAction("Index");
        }
    }
}
