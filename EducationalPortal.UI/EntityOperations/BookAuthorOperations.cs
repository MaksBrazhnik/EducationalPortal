//using EducationalPortal.BLL.ServicesImplementation;
//using EducationalPortal.DAL.DBOperation;
//using EducationalPortal.DAL.RepositoryEFImplementation;
//using EducationalPortal.Domain.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace EducationalPortal.UI.EntityOperations
//{
//    public class BookAuthorOperations
//    {
//        private BookAuthorService bookAuthorService;
//        private BookService bookService;
//        private AuthorService authorService;

//        public BookAuthorOperations()
//        {
//            var educationalPortalContext = new EducationalPortalContext();
//            var authorRepository = new GenericRepository<Author>(educationalPortalContext);
//            var bookRepository = new GenericRepository<Book>(educationalPortalContext);
//            var bookAuthorRepository = new GenericRepository<BookAuthor>(educationalPortalContext);
//            bookAuthorService = new BookAuthorService(bookAuthorRepository);
//            bookService = new BookService(bookRepository);
//            authorService = new AuthorService(authorRepository);
//        }

//        public async Task Add()
//        {
//            var bookAuthor = new BookAuthor();
//            Console.WriteLine("Please enter Author name");
//            string authorName = Console.ReadLine();
//            var author = await authorService.Find().FirstOrDefaultAsync(author => author.Name == authorName);
//            Console.WriteLine("Please enter Book name");
//            string bookName = Console.ReadLine();
//            var books = await bookService.Find().FirstOrDefaultAsync(book => book.Name == bookName);
//            bookAuthor.AuthorId = author.Id;
//            bookAuthor.BookId = books.Id;
//            bookAuthor.Author = author;
//            bookAuthor.Book = books;
//            await bookAuthorService.Add(bookAuthor);
//        }
//    }
//}
