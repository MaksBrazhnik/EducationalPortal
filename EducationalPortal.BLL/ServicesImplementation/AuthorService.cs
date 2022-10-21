using AutoMapper;
using EducationalPortal.DAL.RepositoryEFImplementation;
using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Interfaces.RepositoriesEF;
using EducationalPortal.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace EducationalPortal.BLL.ServicesImplementation
{
    public class AuthorService : IAuthorService
    {
        public IGenericRepository<Author> authorRepository;
        private readonly IMapper mapper;

        public AuthorService(IGenericRepository<Author> authorRepository, IMapper mapper)
        {
            this.authorRepository = authorRepository;
            this.mapper = mapper;
        }

        public async Task<AuthorDTO> GetAuthorDTOByNameAsync(string name)
        {
            var author = await GetAuthorByNameAsync(name);
            return mapper.Map<AuthorDTO>(author);
        }

        public async Task<bool> IsCreatedAuthor(string name)
        {
            var author = await GetAuthorByNameAsync(name);
            return author != null;
        }

        public async Task<AuthorDTO> AddAuthorAsync(AddAuthorDTO addAuthorDTO)
        {
            var author = mapper.Map<Author>(addAuthorDTO);

            if (await IsCreatedAuthor(author.Name))
            {
                return null;
            }

            var id = await authorRepository.CreateAsync(author);
            var createdAuthor = await GetAuthorByIdAsync(id);
            return mapper.Map<AuthorDTO>(createdAuthor);
        }

        public async Task RemoveAuthorAsync(int id)
        {
            await authorRepository.DeleteAsync(id);
        }

        public async Task<AuthorDTO> UpdateAuthorAsync(AuthorDTO updateAuthorDTO)
        {
            var author = await GetAuthorByIdAsync(updateAuthorDTO.Id);
            var updatedAuthor = mapper.Map(updateAuthorDTO, author);
            await authorRepository.UpdateAsync(updatedAuthor);
            return await GetAuthorDTOByNameAsync(updateAuthorDTO.Name);
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await authorRepository.GetByIdAsync(id);
        }

        private async Task<Author> GetAuthorByNameAsync(string name)
        {
            return await authorRepository.Find().FirstOrDefaultAsync(author => author.Name == name);
        }
    }
}
