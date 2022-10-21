//using EducationalPortal.BLL.ServicesImplementation;
//using EducationalPortal.DAL.DBOperation;
//using EducationalPortal.DAL.RepositoryEFImplementation;
//using EducationalPortal.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Query;
//using System.Linq;
//using System.Net.Security;

//namespace EducationalPortal.UI.EntityOperations
//{
//    public class UserCourseOperations
//    {
//        private UserService userService;
//        private CourseService courseService;
//        private UserCourseService userCourseService;
//        private UserCourse userCourse;
//        private GenericRepository<Course> courseRepository;
//        private GenericRepository<User> userRepository;
//        private GenericRepository<UserCourse> userCourseRepository;
//        private GenericRepository<UserMaterial> userMaterialRepository;
//        private GenericRepository<UserSkill> userSkillRepository;
//        private UserSkill userSkill;

//        public UserCourseOperations()
//        {
//            var educationalPortalContext = new EducationalPortalContext();
//            userRepository = new GenericRepository<User>(educationalPortalContext);
//            userCourseRepository = new GenericRepository<UserCourse>(educationalPortalContext);
//            courseRepository = new GenericRepository<Course>(educationalPortalContext);
//            userMaterialRepository = new GenericRepository<UserMaterial>(educationalPortalContext);
//            userSkillRepository = new GenericRepository<UserSkill>(educationalPortalContext);
//            userService = new UserService(userRepository);
//            courseService = new CourseService(courseRepository);
//            userCourseService = new UserCourseService(userCourseRepository);
//            userCourse = new UserCourse();
//            userSkill = new UserSkill();
//        }

//        public async Task Add(int currentUserId)
//        {
//            Console.WriteLine("Enter course name");
//            var courseName = Console.ReadLine();
//            var course = await courseRepository.Find(include: course => course.Include(material => material.CourseMaterials)
//                                                                              .Include(skill => skill.CourseSkills)
//                                                                              .Include(course => course.UserCourses)).FirstOrDefaultAsync(course => course.Name == courseName);
//            var user = await userRepository.Find(include: user => user.Include(skills => skills.UserSkills)
//                                                                      .Include(materials => materials.UserMaterials))
//                                                                      .Include(courses => courses.UserСourses).FirstOrDefaultAsync(user => user.Id == currentUserId);
//            var courseResult = course.UserCourses.Select(course => course.Id).Except(user.UserСourses.Select(course => course.Id));
//            var materialResult = course.CourseMaterials.Select(material => material.LearnMaterialId)
//                            .Except(user.UserMaterials.Select(material => material.LearnMaterialId));
//            var skillToUp = course.CourseSkills.Select(skill => skill.SkillId).Intersect(user.UserSkills.Select(skill => skill.SkillId));
//            var skillToAdd = course.CourseSkills.Select(skill => skill.SkillId).Except(user.UserSkills.Select(skill => skill.SkillId));
//            foreach (var userCourse in courseResult)
//            {
//                await userCourseRepository.CreateAsync(new UserCourse()
//                {
//                    CourseId = course.Id,
//                    UserId = user.Id,
//                    IsPassed = false,
//                    PassPercent = 0
//                });
//            }

//            foreach (var courseMaterialId in materialResult)
//            {
//                await userMaterialRepository.CreateAsync(new UserMaterial()
//                {
//                    UserId = user.Id,
//                    LearnMaterialId = courseMaterialId,
//                    IsPassed = false
//                });
//            }

//            foreach (var courseSkillId in skillToAdd)
//            {
//                await userSkillRepository.CreateAsync(new UserSkill()
//                {
//                    UserId = user.Id,
//                    SkillId = courseSkillId,
//                    Level = 0
//                });
//            }

//            foreach (var courseSkillId in skillToUp)
//            {
//                var userSkill = await userSkillRepository.Find().FirstOrDefaultAsync(userSkill => userSkill.SkillId == courseSkillId);
//                userSkill.Level++;
//                await userSkillRepository.UpdateAsync(userSkill);
//            }
//        }
//    }
//}
