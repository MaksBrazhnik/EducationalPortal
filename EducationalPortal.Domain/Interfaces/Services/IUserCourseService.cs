using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Enums;

namespace EducationalPortal.Domain.Interfaces.Services
{
    public interface IUserCourseService
    {
        public Task<int> AddUserCourseAsync(int courseId, int currentUserId);

        public Task RemoveUserCourseAsync(int id);

        public Task<UserCourse> GetUserCourseByIdAsync(int id);

        public Task<UserMaterial> PassMaterial(int materialId, int courseId, string currentUserEmail);

        public Task<int> GetPassPersent(int courseId, int currentUserId);

        public Task<List<UserCourse>> GetUserCourses(int userId);

        public Task<UserCourseListDTO> GetAllUserCoursesAsync(int userId, int page, SortState sortOrder);

        public Task<int> GetUserIdByEmail(string email);
    }
}
