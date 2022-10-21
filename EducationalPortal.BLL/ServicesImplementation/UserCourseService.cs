using EducationalPortal.DAL.RepositoryEFImplementation;
using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Enums;
using EducationalPortal.Domain.Interfaces.RepositoriesEF;
using EducationalPortal.Domain.Interfaces.Services;
using EducationalPortal.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EducationalPortal.BLL.ServicesImplementation
{
    public class UserCourseService : IUserCourseService
    {
        private static int PAGE_SIZE = 5;
        private IGenericRepository<UserCourse> userCourseRepository;
        private IGenericRepository<Course> courseRepository;
        private IGenericRepository<User> userRepository;
        private IGenericRepository<UserMaterial> userMaterialRepository;
        private IGenericRepository<UserSkill> userSkillRepository;
        private IGenericRepository<LearnMaterial> learnMaterialRepository;

        public UserCourseService(IGenericRepository<UserCourse> userCourseRepository, IGenericRepository<LearnMaterial> learnMaterialRepository, IGenericRepository<Course> courseRepository, IGenericRepository<User> userRepository, IGenericRepository<UserMaterial> userMaterialRepository, IGenericRepository<UserSkill> userSkillRepository)
        {
            this.userCourseRepository = userCourseRepository;
            this.learnMaterialRepository = learnMaterialRepository;
            this.courseRepository = courseRepository;
            this.userMaterialRepository = userMaterialRepository;
            this.userRepository = userRepository;
            this.userSkillRepository = userSkillRepository;
        }

        public async Task<int> AddUserCourseAsync(int courseId, int currentUserId)
        {
            var course = await courseRepository.Find(include: course => course.Include(material => material.CourseMaterials)
                                                                              .Include(skill => skill.CourseSkills)
                                                                              .Include(course => course.UserCourses)).FirstOrDefaultAsync(course => course.Id == courseId);
            var user = await userRepository.Find(include: user => user.Include(skills => skills.UserSkills)
                                                                      .Include(materials => materials.UserMaterials))
                                                                      .Include(courses => courses.UserСourses).FirstOrDefaultAsync(user => user.Id == currentUserId);
            var materialResult = course.CourseMaterials.Select(material => material.LearnMaterialId)
                            .Except(user.UserMaterials.Select(material => material.LearnMaterialId));
            var skillResult = course.CourseSkills.Select(skill => skill.SkillId).Except(user.UserSkills.Select(skill => skill.SkillId));
            foreach (var courseMaterialId in materialResult)
            {
                await userMaterialRepository.CreateAsync(new UserMaterial()
                {
                    UserId = user.Id,
                    LearnMaterialId = courseMaterialId,
                    IsPassed = false
                });
            }

            foreach (var courseSkillId in skillResult)
            {
                await userSkillRepository.CreateAsync(new UserSkill()
                {
                    UserId = user.Id,
                    SkillId = courseSkillId,
                    Level = 0
                });
            }

            var userCourses = user.UserСourses.Select(userCourse => userCourse.Course);
            if (userCourses.Contains(course))
            {
                return 0;
            }
            else
            {
                var userCourse = await userCourseRepository.CreateAsync(new UserCourse()
                {
                    CourseId = course.Id,
                    UserId = user.Id,
                    IsPassed = false,
                    PassPercent = 0
                });
                return userCourse;
            }
        }

        public async Task RemoveUserCourseAsync(int id)
        {
            await userCourseRepository.DeleteAsync(id);
        }

        public async Task<UserCourse> GetUserCourseByIdAsync(int id)
        {
            return await userCourseRepository.GetByIdAsync(id);
        }

        public async Task<UserMaterial> PassMaterial(int materialId, int courseId, string currentUserEmail)
        {
            var material = await learnMaterialRepository.Find()
                                                        .FirstOrDefaultAsync(material => material.Id == materialId);
            var user = await userRepository.Find().FirstOrDefaultAsync(user => user.Email == currentUserEmail);
            var userMaterial = await userMaterialRepository.Find()
                                                           .FirstOrDefaultAsync(um => um.LearnMaterialId == material.Id && um.UserId == user.Id);
            userMaterial.IsPassed = true;
            await userMaterialRepository.UpdateAsync(userMaterial);
            await GetPassPersent(courseId, user.Id);
            return userMaterial;
        }

        public async Task<int> GetPassPersent (int courseId, int currentUserId)
        {
            var course = await courseRepository.Find(include: course => course.Include(course => course.CourseMaterials)
                                                                              .Include(course => course.CourseSkills))
                                                                              .FirstOrDefaultAsync(course => course.Id == courseId);
            var user = await userRepository.Find(include: user => user.Include(user => user.UserMaterials)
                                                                      .Include(user => user.UserSkills)
                                                                      .Include(user => user.UserСourses))
                                                                      .FirstOrDefaultAsync(user => user.Id == currentUserId);
            var userCourseMaterials = course.CourseMaterials.Select(material => material.LearnMaterialId)
                            .Intersect(user.UserMaterials.Select(material => material.LearnMaterialId)).Count();
            var userPassedMaterials = new List<UserMaterial>();
            foreach (var userMaterial in user.UserMaterials)
            {
                if (userMaterial.IsPassed == true)
                {
                    userPassedMaterials.Add(userMaterial);
                }
            }

            var userCoursePassedMaterials = course.CourseMaterials.Select(material => material.LearnMaterialId)
                            .Intersect(userPassedMaterials.Select(material => material.LearnMaterialId)).Count();

            var passPercent = (userCoursePassedMaterials * 100) / userCourseMaterials;

            var userCourse = new UserCourse();
            foreach (var item in user.UserСourses)
            {
                if (item.CourseId == courseId)
                {
                    userCourse = item;
                }
            }

            userCourse.PassPercent = passPercent;
            if (userCourse.PassPercent == 100)
            {
                var courseSkills = course.CourseSkills;
                foreach (var courseSkill in courseSkills)
                {
                    var userSkill = new UserSkill();
                    foreach (var item in user.UserSkills)
                    {
                        if (item.SkillId == courseSkill.SkillId)
                        {
                            userSkill = item;
                            userSkill.Level++;
                            await userSkillRepository.UpdateAsync(userSkill);
                        }
                    }
                }

                userCourse.IsPassed = true;
            }

            await userCourseRepository.UpdateAsync(userCourse);
            return passPercent;
        }

        public async Task<List<UserCourse>> GetUserCourses(int userId)
        {
            var user = await userRepository.Find(include: user => user.Include(user => user.UserСourses)
                                                                      .ThenInclude(userCourses => userCourses.Course))
                                                                      .FirstOrDefaultAsync(user => user.Id == userId);

            return user.UserСourses;
        }

        public async Task<UserCourseListDTO> GetAllUserCoursesAsync(int userId, int page, SortState sortOrder)
        {
            var userCourses = await GetUserCourses(userId);
            switch (sortOrder)
            {
                case SortState.UserCourseASC:
                    userCourses = userCourses.OrderBy(userCourse => userCourse.Id).ToList();
                    break;
                case SortState.UserCourseDESC:
                    userCourses = userCourses.OrderByDescending(userCourse => userCourse.Id).ToList();
                    break;
                default:
                    userCourses = userCourses.OrderBy(userCourse => userCourse.Id).ToList();
                    break;
            }

            var count = userCourses.Count();
            var items = userCourses.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE).ToList();
            var userCourseList = new UserCourseListDTO
            {
                UserCourses = items,
                SortViewModel = new SortViewModel(sortOrder),
                PageViewModel = new PageViewModel(count, page, PAGE_SIZE)
            };
            return userCourseList;
        }

        public async Task<int> GetUserIdByEmail(string email)
        {
            var user = await userRepository.Find().FirstOrDefaultAsync(user => user.Email == email);
            return user.Id;
        }
    }
}
