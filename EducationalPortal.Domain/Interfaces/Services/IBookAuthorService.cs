using EducationalPortal.Domain.Entities;

namespace EducationalPortal.Domain.Interfaces.Services
{
    public interface IBookAuthorService
    {
        public Task<int> AddBookAuthorAsync(int bookId, int authorId);

        public Task<IEnumerable<Author>> GetAuthorAsync(int bookId);
    }
}
