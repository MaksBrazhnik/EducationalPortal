using EducationalPortal.DAL.DBOperation;
using EducationalPortal.DAL.RepositoryEFImplementation;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Interfaces.RepositoriesEF;
using EducationalPortal.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace EducationalPortal.BLL.ServicesImplementation
{
    public class BookAuthorService : IBookAuthorService
    {
        private IGenericRepository<BookAuthor> bookAuthorRepository;
        private IGenericRepository<Author> authorRepository;
        private IGenericRepository<Book> bookRepository;

        public BookAuthorService(IGenericRepository<BookAuthor> bookAuthorRepository, IGenericRepository<Author> authorRepository, IGenericRepository<Book> bookRepository)
        {
            this.bookAuthorRepository = bookAuthorRepository;
            this.authorRepository = authorRepository;
            this.bookRepository = bookRepository;
        }

        public async Task<int> AddBookAuthorAsync(int bookId, int authorId)
        {
            var bookAuthor = await bookAuthorRepository.CreateAsync(new BookAuthor
            {
                BookId = bookId,
                AuthorId = authorId
            });
            return bookAuthor;
        }

        public async Task<IEnumerable<Author>> GetAuthorAsync(int bookId)
        {
            var book = await bookRepository.Find(include: book => book.Include(book => book.BookAuthors))
                                           .FirstOrDefaultAsync(book => book.Id == bookId);
            var authors = new List<Author>();
            foreach (var bookAuthor in book.BookAuthors)
            {
                var author = await authorRepository.Find().FirstOrDefaultAsync(author => author.Id == bookAuthor.Id);
                authors.Add(author);
            }

            return authors;
        }
    }
}
