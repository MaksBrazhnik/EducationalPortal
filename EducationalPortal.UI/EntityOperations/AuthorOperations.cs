//using EducationalPortal.BLL.ServicesImplementation;
//using EducationalPortal.DAL.DBOperation;
//using EducationalPortal.DAL.RepositoryEFImplementation;
//using EducationalPortal.Domain.Entities;
//using EducationalPortal.Validation.Validation;

//namespace EducationalPortal.UI.EntityOperations
//{
//    public class AuthorOperations
//    {
//        private AuthorService authorService;

//        public AuthorOperations()
//        {
//            var educationalPortalContext = new EducationalPortalContext();
//            var authorRepository = new GenericRepository<Author>(educationalPortalContext);
//            authorService = new AuthorService(authorRepository);
//        }

//        public async Task Add()
//        {
//            var author = new Author();
//            var authorValidator = new AuthorValidator();
//            Console.WriteLine("Enter authors name and familyname");
//            author.Name = Console.ReadLine();
//            var result = authorValidator.Validate(author);
//            if (!result.IsValid)
//            {
//                foreach (var failure in result.Errors)
//                {
//                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
//                }
//            }

//            await authorService.Add(author);
//        }
//    }
//}
