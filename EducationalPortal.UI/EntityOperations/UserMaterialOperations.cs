//using EducationalPortal.DAL.DBOperation;
//using EducationalPortal.DAL.RepositoryEFImplementation;
//using EducationalPortal.Domain.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace EducationalPortal.UI.EntityOperations
//{
//    public class UserMaterialOperations
//    {
//        private GenericRepository<UserMaterial> userMaterialRepository;
//        private GenericRepository<Course> courseRepository;
//        private GenericRepository<User> userRepository;

//        public UserMaterialOperations()
//        {
//            var educationalPortalContext = new EducationalPortalContext();
//            userMaterialRepository = new GenericRepository<UserMaterial>(educationalPortalContext);
//            courseRepository = new GenericRepository<Course>(educationalPortalContext);
//            userRepository = new GenericRepository<User>(educationalPortalContext);
//        }

//        public async Task Add(int courseId, int userId)
//        {
//            var userMaterial = new UserMaterial();
//            var courses = courseRepository.Find(include: course => course.Include(materials => materials.CourseMaterials)).FirstOrDefault(course => course.Id == courseId);
//            var users = await userRepository.Find().FirstOrDefaultAsync(user => user.Id == userId);

//            foreach (var courseMaterial in courses.CourseMaterials)
//            {
//                await userMaterialRepository.CreateAsync(new UserMaterial()
//                {
//                    UserId = users.Id,
//                    LearnMaterialId = courseMaterial.LearnMaterialId,
//                    IsPassed = false
//                });
//            }
//        }
//    }
//}
