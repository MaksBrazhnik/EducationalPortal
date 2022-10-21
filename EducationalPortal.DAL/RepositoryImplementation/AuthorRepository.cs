using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Interfaces.Repositories;

namespace EducationalPortal.DAL.RepositoryImplementation
{
    public class AuthorRepository : IAuthorRepository
    {
        public List<Author> authors = new List<Author>();

        public AuthorRepository(List<Author> authors)
        {
            this.authors = authors;
        }

        public Author Create(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException("author is null");
            }

            var previousId = authors.LastOrDefault()?.Id ?? 0;
            author.Id = previousId++;
            authors.Add(author);
            return author;
        }

        public void Delete(int id)
        {
            authors.RemoveAll(p => p.Id == id);
        }

        public Author GetById(int id)
        {
            return (Author)authors.Find(p => p.Id == id);
        }

        public bool Update(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException("author");
            }

            int index = authors.FindIndex(p => p.Id == author.Id);
            if (index == -1)
            {
                return false;
            }

            authors.RemoveAt(index);
            authors.Add(author);
            return true;
        }
    }
}
