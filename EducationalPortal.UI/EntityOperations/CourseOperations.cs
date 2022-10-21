//using EducationalPortal.BLL.ServicesImplementation;
//using EducationalPortal.DAL;
//using EducationalPortal.DAL.DBOperation;
//using EducationalPortal.DAL.RepositoryEFImplementation;
//using EducationalPortal.Domain.Entities;
//using EducationalPortal.Validation.Validation;
//using Microsoft.EntityFrameworkCore;

//namespace EducationalPortal.UI.EntityOperations
//{
//    public class CourseOperations
//    {
//        private CourseService courseService;

//        public CourseOperations()
//        {
//            var educationalPortalContext = new EducationalPortalContext();
//            var courseRepository = new GenericRepository<Course>(educationalPortalContext);
//            courseService = new CourseService(courseRepository);
//        }

//        public async Task Add()
//        {
//            var course = new Course();
//            var courseValidator = new CourseValidator();
//            Console.WriteLine("Enter course name");
//            course.Name = Console.ReadLine();
//            Console.WriteLine("Enter description");
//            course.Description = Console.ReadLine();
//            var result = courseValidator.Validate(course);
//            if (!result.IsValid)
//            {
//                foreach (var failure in result.Errors)
//                {
//                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
//                }
//            }

//            await courseService.Add(course);
//            Console.WriteLine("Course is created");
//        }

//        public async Task Delete()
//        {
//            Console.WriteLine(MenuStrings.MenuStrings.NAME_ENTER);
//            string name = Console.ReadLine();
//            var courses = await courseService.Find().FirstOrDefaultAsync(course => course.Name == name);
//            int id = courses.Id;
//            Console.WriteLine(MenuStrings.MenuStrings.REFINEMENT_TYPE_CHOOSE);
//            int choose = int.Parse(Console.ReadLine());
//            if (choose == 0)
//            {
//                await courseService.Remove(id);
//                Console.WriteLine("Course is deleted");
//            }
//            else if (choose == 1)
//            {
//                Console.WriteLine("Course is not deleted");
//            }
//            else
//            {
//                Console.WriteLine("Unsigned choise");
//            }
//        }

//        public async Task ShowCourses()
//        {
//            var courses = courseService.Find();
//            foreach (var course in courses)
//            {
//                Console.WriteLine("Course name: " + course.Name);
//                Console.WriteLine("Course description: " + course.Description);
//            }
//        }
//    }
//}
