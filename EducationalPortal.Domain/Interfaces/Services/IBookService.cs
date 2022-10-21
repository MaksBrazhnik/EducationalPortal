using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EducationalPortal.Domain.Interfaces.Services
{
    public interface IBookService
    {
        public Task<BookDTO> GetBookDTOByNameAsync(string name);

        public Task<bool> IsCreatedBook(string name);

        public Task<BookDTO> AddBookAsync(AddBookDTO addBookDTO);

        public Task RemoveBookAsync(int id);

        public Task<BookDTO> UpdateBookAsync(BookDTO updatebookDTO);

        public Task<BookDTO> GetBookDTOByIdAsync(int id);

        public Task<List<SelectListItem>> GetAuthorsSelectList();

        public Task<IEnumerable<BookDTO>> GetBooksDTOAsync();

        public Task<Book> GetBookByIdAsync(int id);

        public Task<BookListDTO> GetAllBooksAsync(int page, SortState sortOrder);
    }
}
