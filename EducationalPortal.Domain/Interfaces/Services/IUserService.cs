using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Entities;

namespace EducationalPortal.Domain.Interfaces.Services
{
    public interface IUserService
    {
        public Task<UserDTO> GetUserDTOByEmailAsync(string email);

        public Task<bool> IsRegisteredUser(string email);

        public Task<UserDTO> IsRegisteredUser(string email, string password);

        public Task<UserDTO> AddUserAsync(UserRegistrationDTO userRegistrationDTO);

        public Task<UserDTO> UpdateUserAsync(UserDTO userDTO);

        public Task<User> GetUserByIdAsync(int id);
    }
}
