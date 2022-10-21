using EducationalPortal.DAL;
using EducationalPortal.DAL.RepositoryEFImplementation;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Utils;
using Microsoft.EntityFrameworkCore;

namespace EducationalPortal.BLL.ServicesImplementation
{
    public class LoginService
    {
        private CurrentUser currentUser;
        private GenericRepository<User> userRepository;
        private HashVerify hashVerify = new HashVerify();

        public LoginService(GenericRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> Login(string email, string password)
        {
            var users = await userRepository.Find().FirstOrDefaultAsync(user => user.Email == email);
            if (hashVerify.Verified(password, users.Password) == true)
            {
                currentUser.Id = users.Id;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetCurrentUserId()
        {
            return currentUser.Id;
        }

        public async Task Unlogin()
        {
            currentUser.Id = 0;
        }
    }
}
