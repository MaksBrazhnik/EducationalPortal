//using EducationalPortal.BLL.Interfaces;
//using EducationalPortal.DAL.DBOperation;
//using EducationalPortal.DAL.RepositoryEFImplementation;
//using EducationalPortal.Domain.Entities;
//using EducationalPortal.UI.Enums;
//using EducationalPortal.Validation.Validation;
//using Microsoft.EntityFrameworkCore;

//namespace EducationalPortal.UI.EntityOperations
//{
//    public class UserAccountOperations : IUserAccountOperations
//    {
//        private GenericRepository<User> userRepository;
//        private GenericRepository<Course> courseRepository;
//        private GenericRepository<Skill> skillRepository;
//        private GenericRepository<Article> articleRepository;
//        private GenericRepository<Book> bookRepository;
//        private GenericRepository<Video> videoRepository;
//        private GenericRepository<UserMaterial> userMaterialRepository;
//        private GenericRepository<Author> authorRepository;
//        private UserChangeOptions userChangeOptions = new UserChangeOptions();

//        public UserAccountOperations()
//        {
//            var educationalPortalContext = new EducationalPortalContext();
//            userRepository = new GenericRepository<User>(educationalPortalContext);
//            courseRepository = new GenericRepository<Course>(educationalPortalContext);
//            skillRepository = new GenericRepository<Skill>(educationalPortalContext);
//            articleRepository = new GenericRepository<Article>(educationalPortalContext);
//            bookRepository = new GenericRepository<Book>(educationalPortalContext);
//            videoRepository = new GenericRepository<Video>(educationalPortalContext);
//            authorRepository = new GenericRepository<Author>(educationalPortalContext);
//        }

//        public async Task ChangeUserInformation(int userId)
//        {
//            var user = await userRepository.Find().FirstOrDefaultAsync(user => user.Id == userId);
//            var validator = new UserValidator();
//            bool inChange = true;
//            while (inChange)
//            {
//                Console.WriteLine(MenuStrings.MenuStrings.USER_CHANGE);
//                userChangeOptions = (UserChangeOptions)int.Parse(Console.ReadLine());
//                switch (userChangeOptions)
//                {
//                    case UserChangeOptions.Name:
//                        Console.WriteLine("Enter new name");
//                        user.Name = Console.ReadLine();
//                        var result = validator.Validate(user);
//                        if (!result.IsValid)
//                        {
//                            foreach (var failure in result.Errors)
//                            {
//                                Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
//                            }
//                        }

//                        break;
//                    case UserChangeOptions.Familyname:
//                        Console.WriteLine("Enter new familyname");
//                        user.FamilyName = Console.ReadLine();
//                        result = validator.Validate(user);
//                        if (!result.IsValid)
//                        {
//                            foreach (var failure in result.Errors)
//                            {
//                                Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
//                            }
//                        }

//                        break;
//                    case UserChangeOptions.Email:
//                        Console.WriteLine("Enter new email");
//                        user.Email = Console.ReadLine();
//                        result = validator.Validate(user);
//                        if (!result.IsValid)
//                        {
//                            foreach (var failure in result.Errors)
//                            {
//                                Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
//                            }
//                        }

//                        break;
//                    case UserChangeOptions.End:
//                        await userRepository.UpdateAsync(user);
//                        inChange = false;
//                        break;
//                    default:
//                        break;
//                }
//            }
//        }

//        public async Task ShowCourses(int userId)
//        {
//            var user = await userRepository.Find(include: user => user.Include(course => course.UserСourses)).FirstOrDefaultAsync(user => user.Id == userId);
//            foreach (var userCourse in user.UserСourses)
//            {
//                var course = await courseRepository.Find().FirstOrDefaultAsync(course => course.Id == userCourse.CourseId);
//                Console.WriteLine("Course name: " + course.Name);
//                Console.WriteLine("Course description: " + course.Description);
//            }
//        }

//        public async Task ShowSkills(int userId)
//        {
//            var user = await userRepository.Find(include: user => user.Include(skill => skill.UserSkills)).FirstOrDefaultAsync(user => user.Id == userId);
//            foreach (var userSkill in user.UserSkills)
//            {
//                var skill = await skillRepository.Find().FirstOrDefaultAsync(skill => skill.Id == userSkill.SkillId);
//                Console.WriteLine("Skill name: " + skill.Name);
//                Console.WriteLine("Level: " + userSkill.Level);
//            }
//        }

//        public async Task ShowUserInformation(int userId)
//        {
//            var user = await userRepository.Find().FirstOrDefaultAsync(user => user.Id == userId);
//            Console.WriteLine("User name: " + user.Name);
//            Console.WriteLine("User familyname: " + user.FamilyName);
//            Console.WriteLine("User email: " + user.Email);
//        }

//        public async Task ShowUserMaterials(int userId)
//        {
//            var user = await userRepository.Find(include: user => user.Include(material => material.UserMaterials)).FirstOrDefaultAsync(user => user.Id == userId);
//            foreach (var userMaterial in user.UserMaterials)
//            {
//                var article = await articleRepository.Find().FirstOrDefaultAsync(article => article.Id == userMaterial.LearnMaterialId);
//                var book = await bookRepository.Find(include: book => book.Include(bookAuthor => bookAuthor.BookAuthors))
//                                               .FirstOrDefaultAsync(book => book.Id == userMaterial.LearnMaterialId);
//                var video = await videoRepository.Find().FirstOrDefaultAsync(video => video.Id == userMaterial.LearnMaterialId);
//                if (article != null)
//                {
//                    Console.WriteLine("Article name: " + article.Name);
//                    Console.WriteLine("Publication date: " + article.PublicationDate);
//                    Console.WriteLine("Resourse: " + article.Resource);
//                }
//                else if (book != null)
//                {
//                    Console.WriteLine("Book name: " + book.Name);
//                    Console.WriteLine("Publication date: " + book.PublicationDate);
//                    Console.WriteLine("Count of pages: " + book.PageCount);
//                    foreach (var bookAuthors in book.BookAuthors)
//                    {
//                        var author = await authorRepository.Find().FirstOrDefaultAsync(author => author.Id == bookAuthors.AuthorId);
//                        Console.WriteLine("Author: " + author.Name);
//                    }
//                }
//                else if (video != null)
//                {
//                    Console.WriteLine("Video name: " + video.Name);
//                    Console.WriteLine("Quality: " + video.Quality);
//                }
//                else
//                {
//                    break;
//                }
//            }
//        }
//    }
//}
