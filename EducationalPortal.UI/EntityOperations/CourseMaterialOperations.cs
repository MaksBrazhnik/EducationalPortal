//using EducationalPortal.BLL.ServicesImplementation;
//using EducationalPortal.DAL.DBOperation;
//using EducationalPortal.DAL.RepositoryEFImplementation;
//using EducationalPortal.Domain.Entities;
//using EducationalPortal.Domain.Enums;
//using Microsoft.EntityFrameworkCore;

//namespace EducationalPortal.UI.EntityOperations
//{
//    public class CourseMaterialOperations
//    {
//        private CourseService courseService;
//        private ArticleService articleService;
//        private BookService bookService;
//        private VideoService videoService;
//        private CourseMaterialService courseMaterialService;
//        private LearnMaterialsType learnMaterialsType = new LearnMaterialsType();

//        public CourseMaterialOperations()
//        {
//            var educationalPortalContext = new EducationalPortalContext();
//            var courseRepository = new GenericRepository<Course>(educationalPortalContext);
//            var articleRepository = new GenericRepository<Article>(educationalPortalContext);
//            var bookRepository = new GenericRepository<Book>(educationalPortalContext);
//            var videoRepository = new GenericRepository<Video>(educationalPortalContext);
//            var courseMaterialRepository = new GenericRepository<CourseMaterial>(educationalPortalContext);
//            courseService = new CourseService(courseRepository);
//            articleService = new ArticleService(articleRepository);
//            bookService = new BookService(bookRepository);
//            videoService = new VideoService(videoRepository);
//            courseMaterialService = new CourseMaterialService(courseMaterialRepository);
//            learnMaterialsType = new LearnMaterialsType();
//        }

//        public async Task Add()
//        {
//            var courseMaterial = new CourseMaterial();
//            Console.WriteLine("Please enter course name");
//            var courseName = Console.ReadLine();
//            var course = await courseService.Find().FirstOrDefaultAsync(course => course.Name == courseName);
//            bool inAdding = true;
//            while (inAdding)
//            {
//                Console.WriteLine(MenuStrings.MenuStrings.MATERIAL_TYPE_CHOOSE);
//                learnMaterialsType = (LearnMaterialsType)int.Parse(Console.ReadLine());
//                switch (learnMaterialsType)
//                {
//                    case LearnMaterialsType.Article:
//                        Console.WriteLine("Enter article name");
//                        var articleName = Console.ReadLine();
//                        var article = await articleService.Find().FirstOrDefaultAsync(article => article.Name == articleName);
//                        courseMaterial.LearnMaterialId = article.Id;
//                        courseMaterial.CourseId = course.Id;
//                        courseMaterial.Course = course;
//                        courseMaterial.LearnMaterial = article;
//                        await courseMaterialService.Add(courseMaterial);
//                        break;
//                    case LearnMaterialsType.Book:
//                        Console.WriteLine("Enter book name");
//                        var bookName = Console.ReadLine();
//                        var book = await bookService.Find().FirstOrDefaultAsync(book => book.Name == bookName);
//                        courseMaterial.LearnMaterialId = book.Id;
//                        courseMaterial.CourseId = course.Id;
//                        courseMaterial.Course = course;
//                        courseMaterial.LearnMaterial = book;
//                        await courseMaterialService.Add(courseMaterial);
//                        break;
//                    case LearnMaterialsType.Video:
//                        Console.WriteLine("Enter video name");
//                        var videoName = Console.ReadLine();
//                        var video = await videoService.Find().FirstOrDefaultAsync(video => video.Name == videoName);
//                        courseMaterial.LearnMaterialId = video.Id;
//                        courseMaterial.CourseId = course.Id;
//                        courseMaterial.Course = course;
//                        courseMaterial.LearnMaterial = video;
//                        await courseMaterialService.Add(courseMaterial);
//                        break;
//                    default:
//                        inAdding = false;
//                        break;
//                }
//            }
//        }
//    }
//}

