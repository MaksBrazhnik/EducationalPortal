using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Entities;

namespace EducationalPortal.Domain.Interfaces.Services
{
    public interface IAuthorService
    {
        public Task<AuthorDTO> GetAuthorDTOByNameAsync(string name);

        public Task<bool> IsCreatedAuthor(string name);

        public Task<AuthorDTO> AddAuthorAsync(AddAuthorDTO addAuthorDTO);

        public Task RemoveAuthorAsync(int id);

        public Task<AuthorDTO> UpdateAuthorAsync(AuthorDTO updateAuthorDTO);

        public Task<Author> GetAuthorByIdAsync(int id);
    }
}
