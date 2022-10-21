//using EducationalPortal.BLL.ServicesImplementation;
//using EducationalPortal.DAL;
//using EducationalPortal.DAL.DBOperation;
//using EducationalPortal.DAL.RepositoryEFImplementation;
//using EducationalPortal.Domain.Entities;
//using EducationalPortal.Validation.Validation;
//using FluentValidation.Results;
//using Microsoft.EntityFrameworkCore;

//namespace EducationalPortal.UI.EntityOperations
//{
//    public class UserOperations
//    {
//        private HashVerify hashVerify = new HashVerify();
//        private UserService userService;

//        public UserOperations()
//        {
//            var educationalPortalContext = new EducationalPortalContext();
//            var userRepository = new GenericRepository<User>(educationalPortalContext);
//            userService = new UserService(userRepository);
//        }

//        public string UserEmail()
//        {
//            Console.WriteLine("Please enter your email");
//            string email = Console.ReadLine();
//            return email;
//        }

//        public string UserPassword()
//        {
//            Console.WriteLine("Please enter your password");
//            string password = Console.ReadLine();
//            return password;
//        }

//        public async Task Add()
//        {
//            var user = new User();
//            var userValidator = new UserValidator();
//            Console.WriteLine("Please enter your name");
//            user.Name = Console.ReadLine();
//            Console.WriteLine("Please enter your familyname");
//            user.FamilyName = Console.ReadLine();
//            Console.WriteLine("Please enter your email");
//            user.Email = Console.ReadLine();
//            Console.WriteLine("Please create your password");
//            user.Password = hashVerify.HashPassword(Console.ReadLine());
//            var result = userValidator.Validate(user);
//            if (!result.IsValid)
//            {
//                foreach (var failure in result.Errors)
//                {
//                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
//                }
//            }

//            await userService.Add(user);
//            Console.WriteLine("Registration successful");
//        }

//        public async Task Delete()
//        {
//            Console.WriteLine("Please enter user email");
//            string email = Console.ReadLine();
//            var users = await userService.Find().FirstOrDefaultAsync(user => user.Email == email);
//            int id = users.Id;
//            int choose = int.Parse(Console.ReadLine());
//            if (choose == 0)
//            {
//                await userService.Remove(id);
//                Console.WriteLine("Your data is deleted");
//            }
//            else if (choose == 1)
//            {
//                Console.WriteLine("Your data is not deleted");
//            }
//            else
//            {
//                Console.WriteLine("Unsigned choise");
//            }
//        }
//    }
//}
