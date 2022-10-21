using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Interfaces.Repositories;

namespace EducationalPortal.DAL.RepositoryImplementation
{
    public class BookRepository : IBookRepository
    {
        public List<Book> books = new List<Book>();

        public BookRepository(List<Book> books)
        {
            this.books = books;
        }

        public Book Create(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException("Book is null");
            }

            var previousId = books.LastOrDefault()?.Id ?? 0;
            book.Id = previousId++;
            books.Add(book);
            return book;
        }

        public void Delete(int id)
        {
            books.RemoveAll(p => p.Id == id);
        }

        public Book GetById(int id)
        {
            return (Book)books.Find(p => p.Id == id);
        }

        public bool Update(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException("book");
            }

            int index = books.FindIndex(p => p.Id == book.Id);
            if (index == -1)
            {
                return false;
            }

            books.RemoveAt(index);
            books.Add(book);
            return true;
        }
    }
}
