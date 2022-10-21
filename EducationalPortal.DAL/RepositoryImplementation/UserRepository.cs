using EducationalPortal.DAL.JSONOperation;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EducationalPortal.DAL.RepositoryImplementation
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users;
        private SerializationJSON _serializationJSON = new SerializationJSON();

        public UserRepository(List<User> users)
        {
           _users = users;
        }

        public User Create(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user is null");
            }

            var previousId = _users.LastOrDefault()?.Id ?? 0;
            user.Id = previousId++;
            _users.Add(user);
            return user;
        }

        public void Delete(int id)
        {
            _users.RemoveAll(p => p.Id == id);
        }

        public User GetById(int id)
        {
            return (User)_users.Find(p => p.Id == id);
        }

        public bool Update(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            int index = _users.FindIndex(p => p.Id == user.Id);
            if (index == -1)
            {
                return false;
            }

            _users.RemoveAt(index);
            _users.Add(user);
            return true;
        }
    }
}
