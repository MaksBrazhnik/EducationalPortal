//using EducationalPortal.DAL.DBOperation;
//using EducationalPortal.DAL.RepositoryEFImplementation;
//using EducationalPortal.Domain.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace EducationalPortal.UI.EntityOperations
//{
//    public class UserSkillOperations
//    {
//        private GenericRepository<UserSkill> userSkillRepository;
//        private GenericRepository<Course> courseRepository;
//        private GenericRepository<User> userRepository;

//        public UserSkillOperations()
//        {
//            var educationalPortalContext = new EducationalPortalContext();
//            userSkillRepository = new GenericRepository<UserSkill>(educationalPortalContext);
//            courseRepository = new GenericRepository<Course>(educationalPortalContext);
//            userRepository = new GenericRepository<User>(educationalPortalContext);
//        }

//        public async Task Add(int courseId, int userId)
//        {
//            var userMaterial = new UserMaterial();
//            var course = courseRepository.Find(include: course => course.Include(skills => skills.CourseSkills)).FirstOrDefault(course => course.Id == courseId);
//            var user = userRepository.Find(include: user => user.Include(skills => skills.UserSkills)).FirstOrDefault(user => user.Id == userId);
//            foreach (var courseSkill in course.CourseSkills)
//            {
//                foreach (var userSkill in user.UserSkills)
//                {
//                    if (userSkill.Id == courseSkill.Id)
//                    {
//                        userSkill.Level++;
//                        userSkillRepository.UpdateAsync(userSkill);
//                    }
//                    else
//                    {
//                        await userSkillRepository.CreateAsync(new UserSkill()
//                        {
//                            UserId = user.Id,
//                            SkillId = courseSkill.SkillId,
//                            User = user,
//                            Skill = courseSkill.Skill,
//                        });
//                    }
//                }
//            }
//        }
//    }
//}