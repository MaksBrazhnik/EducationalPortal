using AutoMapper;
using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Interfaces.RepositoriesEF;
using EducationalPortal.Domain.Interfaces.Services;
using EducationalPortal.Utils;
using Microsoft.EntityFrameworkCore;

namespace EducationalPortal.BLL.ServicesImplementation
{
    public class UserService : IUserService
    {
        private IGenericRepository<User> userRepository;
        private readonly IMapper mapper;
        private HashVerify hashVerify;

        public UserService(IGenericRepository<User> userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            hashVerify = new HashVerify();
        }

        public async Task<UserDTO> GetUserDTOByEmailAsync(string email)
        {
            var user = await GetUserByEmailAsync(email);
            return mapper.Map <UserDTO>(user);
        }

        public async Task<bool> IsRegisteredUser(string email)
        {
            var user = await GetUserByEmailAsync(email);
            return user != null;
        }

        public async Task<UserDTO> IsRegisteredUser(string email, string password)
        {
            var user = await GetUserByEmailAsync(email);
            return user != null && hashVerify.Verified(password, user.Password)
                ? mapper.Map<UserDTO>(user)
                : null;
        }

        public async Task<UserDTO> AddUserAsync(UserRegistrationDTO userRegistrationDTO)
        {
            var user = mapper.Map<User>(userRegistrationDTO);
            user.Password = hashVerify.HashPassword(user.Password);

            if (await IsRegisteredUser(user.Email))
            {
                return null;
            }

            var id = await userRepository.CreateAsync(user);
            var createdUser = await GetUserByIdAsync(id);
            return mapper.Map<UserDTO>(createdUser);
        }

        public async Task<UserDTO> UpdateUserAsync(UserDTO updateUserDTO)
        {
            var user = await GetUserByIdAsync(updateUserDTO.Id);
            var updatedUser = mapper.Map(updateUserDTO, user);
            await userRepository.UpdateAsync(updatedUser);
            return await GetUserDTOByEmailAsync(updateUserDTO.Email);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await userRepository.GetByIdAsync(id);
        }

        private async Task<User> GetUserByEmailAsync(string email)
        {
            return await userRepository.Find(include: user => user
                                       .Include(user => user.UserSkills)
                                       .ThenInclude(userSkills => userSkills.Skill))
                                       .FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}
