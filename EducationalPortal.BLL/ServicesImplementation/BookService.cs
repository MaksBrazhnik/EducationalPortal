using AutoMapper;
using EducationalPortal.DAL.RepositoryEFImplementation;
using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Enums;
using EducationalPortal.Domain.Interfaces.RepositoriesEF;
using EducationalPortal.Domain.Interfaces.Services;
using EducationalPortal.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EducationalPortal.BLL.ServicesImplementation
{
    public class BookService : IBookService
    {
        public IGenericRepository<Book> bookRepository;
        public IGenericRepository<Author> authorRepository;
        private const int PAGE_SIZE = 5;
        private readonly IMapper mapper;

        public BookService(IGenericRepository<Book> bookRepository, IGenericRepository<Author> authorRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
            this.mapper = mapper;
        }

        public async Task<BookDTO> GetBookDTOByNameAsync(string name)
        {
            var book = await GetBookByNameAsync(name);
            return mapper.Map<BookDTO>(book);
        }

        public async Task<BookDTO> GetBookDTOByIdAsync(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);
            return mapper.Map<BookDTO>(book);
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await bookRepository.GetByIdAsync(id);
        }

        public async Task<bool> IsCreatedBook(string name)
        {
            var book = await GetBookByNameAsync(name);
            return book != null;
        }

        public async Task<BookDTO> AddBookAsync(AddBookDTO addBookDTO)
        {
            var book = mapper.Map<Book>(addBookDTO);

            if (await IsCreatedBook(book.Name))
            {
                return null;
            }

            var id = await bookRepository.CreateAsync(book);
            var createdBook = await GetBookByIdAsync(id);
            return mapper.Map<BookDTO>(createdBook);
        }

        public async Task RemoveBookAsync(int id)
        {
            await bookRepository.DeleteAsync(id);
        }

        public async Task<BookDTO> UpdateBookAsync(BookDTO updatebookDTO)
        {
            var book = await GetBookByIdAsync(updatebookDTO.Id);
            var updatedbook = mapper.Map(updatebookDTO, book);
            await bookRepository.UpdateAsync(updatedbook);
            return await GetBookDTOByNameAsync(updatebookDTO.Name);
        }

        public async Task<List<SelectListItem>> GetAuthorsSelectList()
        {
            return await authorRepository.Find()
                                         .Select(author => new SelectListItem
                                         {
                                             Text = author.Name,
                                             Value = author.Id.ToString()
                                         }).ToListAsync();
        }

        public async Task<IEnumerable<BookDTO>> GetBooksDTOAsync()
        {
            var books = await GetBooksAsync();
            var bookDTOs = new List<BookDTO>();
            books.ForEach(book => bookDTOs.Add(new BookDTO()
            {
                Id = book.Id,
                Name = book.Name,
                Format = book.Format,
                PageCount = book.PageCount,
                PublicationDate = book.PublicationDate,
                Author = string.Join(", ", book.BookAuthors.Select(book => book.Author.Name))
            }));
            return bookDTOs;
        }

        public async Task<BookListDTO> GetAllBooksAsync(int page, SortState sortOrder)
        {
            var books = await GetBooksDTOAsync();
            switch (sortOrder)
            {
                case SortState.BookASC:
                    books = books.OrderBy(book => book.Name).ToList();
                    break;
                case SortState.BookDESC:
                    books = books.OrderByDescending(book => book.Name).ToList();
                    break;
                default:
                    books = books.OrderBy(book => book.Id).ToList();
                    break;
            }

            var count = books.Count();
            var items = books.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE).ToList();
            var bookList = new BookListDTO
            {
                Books = items,
                SortViewModel = new SortViewModel(sortOrder),
                PageViewModel = new PageViewModel(count, page, PAGE_SIZE)
            };
            return bookList;
        }

        private async Task<List<Book>> GetBooksAsync()
        {
            return await bookRepository.Find(include: book => book.Include(book => book.BookAuthors)
                                                                  .ThenInclude(bookAuthor => bookAuthor.Author)).ToListAsync();
        }

        private async Task<Book> GetBookByNameAsync(string name)
        {
            return await bookRepository.Find().FirstOrDefaultAsync(book => book.Name == name);
        }
    }
}
