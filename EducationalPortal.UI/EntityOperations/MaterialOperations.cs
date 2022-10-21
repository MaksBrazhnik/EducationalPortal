//using EducationalPortal.BLL.ServicesImplementation;
//using EducationalPortal.DAL.DBOperation;
//using EducationalPortal.DAL.RepositoryEFImplementation;
//using EducationalPortal.DAL.RepositoryImplementation;
//using EducationalPortal.Domain.Entities;
//using EducationalPortal.Domain.Enums;
//using EducationalPortal.UI.Enums;
//using EducationalPortal.Validation.Validation;
//using FluentValidation.Results;
//using Microsoft.EntityFrameworkCore;

//namespace EducationalPortal.UI.EntityOperations
//{
//    public class MaterialOperations
//    {
//        private ArticleService articleService;
//        private BookService bookService;
//        private VideoService videoService;
//        private AuthorService authorService;
//        private BookAuthorService bookAuthorService;
//        private LearnMaterialsType learnMaterialsType;
//        private AuthorAdd authorAdd;

//        public MaterialOperations()
//        {
//            var educationalPortalContext = new EducationalPortalContext();
//            var articleRepository = new GenericRepository<Article>(educationalPortalContext);
//            var bookRepository = new GenericRepository<Book>(educationalPortalContext);
//            var videoRepository = new GenericRepository<Video>(educationalPortalContext);
//            var authorRepository = new GenericRepository<Author>(educationalPortalContext);
//            var bookAythorRepository = new GenericRepository<BookAuthor>(educationalPortalContext);
//            articleService = new ArticleService(articleRepository);
//            bookService = new BookService(bookRepository);
//            videoService = new VideoService(videoRepository);
//            authorService = new AuthorService(authorRepository);
//            bookAuthorService = new BookAuthorService(bookAythorRepository);
//        }

//        public async Task Add()
//        {
//            bool inCreating = true;
//            while (inCreating)
//            {
//                Console.WriteLine(MenuStrings.MenuStrings.MATERIAL_TYPE_CHOOSE);
//                learnMaterialsType = (LearnMaterialsType)int.Parse(Console.ReadLine());
//                switch (learnMaterialsType)
//                {
//                    case LearnMaterialsType.Article:
//                        var article = new Article();
//                        var articleValidator = new ArticleValidator();
//                        Console.WriteLine("Enter article name");
//                        article.Name = Console.ReadLine();
//                        Console.WriteLine("Enter publication date in xx/xx/xxxx format");
//                        article.PublicationDate = DateTime.Parse(Console.ReadLine());
//                        Console.WriteLine("Enter resourse where is this article publicated");
//                        article.Resource = Console.ReadLine();
//                        article.LearnMaterialsType = learnMaterialsType;
//                        var result = articleValidator.Validate(article);
//                        if (!result.IsValid)
//                        {
//                            foreach (var failure in result.Errors)
//                            {
//                                Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
//                            }
//                        }

//                        await articleService.Add(article);
//                        break;
//                    case LearnMaterialsType.Book:
//                        var book = new Book();
//                        var bookAuthor = new BookAuthor();
//                        var bookValidator = new BookValidator();
//                        var authorValidator = new AuthorValidator();
//                        Console.WriteLine("Enter book name");
//                        book.Name = Console.ReadLine();
//                        Console.WriteLine("Enter publication date in xx/xx/xxxx format");
//                        book.PublicationDate = DateTime.Parse(Console.ReadLine());
//                        Console.WriteLine("Enter book format");
//                        book.Format = Console.ReadLine();
//                        Console.WriteLine("Enter number of pages");
//                        book.PageCount = int.Parse(Console.ReadLine());
//                        book.LearnMaterialsType = learnMaterialsType;
//                        Console.WriteLine("Enter author name");
//                        result = bookValidator.Validate(book);
//                        if (!result.IsValid)
//                        {
//                            foreach (var failure in result.Errors)
//                            {
//                                Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
//                            }
//                        }

//                        await bookService.Add(book);
//                        bool isAdding = true;
//                        while (isAdding)
//                        {
//                            Console.WriteLine(MenuStrings.MenuStrings.ADD_AUTHOR);
//                            authorAdd = (AuthorAdd)int.Parse(Console.ReadLine());
//                            switch (authorAdd)
//                            {
//                                case AuthorAdd.AddAuthor:
//                                    Console.WriteLine("Enter author name");
//                                    var authorName = Console.ReadLine();
//                                    var author = await authorService.Find().FirstOrDefaultAsync(author => author.Name == authorName);
//                                    if (author != null)
//                                    {
//                                        bookAuthor.AuthorId = author.Id;
//                                        bookAuthor.BookId = book.Id;
//                                        await bookAuthorService.Add(bookAuthor);
//                                    }
//                                    else
//                                    {
//                                        var newAuthor = new Author();
//                                        newAuthor.Name = authorName;
//                                        result = authorValidator.Validate(newAuthor);
//                                        if (!result.IsValid)
//                                        {
//                                            foreach (var failure in result.Errors)
//                                            {
//                                                Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
//                                            }
//                                        }

//                                        await authorService.Add(newAuthor);
//                                        bookAuthor.AuthorId = newAuthor.Id;
//                                        bookAuthor.BookId = book.Id;
//                                        await bookAuthorService.Add(bookAuthor);
//                                    }

//                                    break;
//                                case AuthorAdd.Exit:
//                                    isAdding = false;
//                                    break;
//                            }
//                        }

//                        break;
//                    case LearnMaterialsType.Video:
//                        var video = new Video();
//                        var videoValidator = new VideoValidator();
//                        Console.WriteLine("Enter video name");
//                        video.Name = Console.ReadLine();
//                        Console.WriteLine("Enter video length");
//                        video.Length = double.Parse(Console.ReadLine());
//                        Console.WriteLine("Enter video quality");
//                        video.Quality = Console.ReadLine();
//                        video.LearnMaterialsType = learnMaterialsType;
//                        result = videoValidator.Validate(video);
//                        if (!result.IsValid)
//                        {
//                            foreach (var failure in result.Errors)
//                            {
//                                Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
//                            }
//                        }

//                        await videoService.Add(video);
//                        break;
//                    default:
//                        inCreating = false;
//                        break;
//                }
//            }
//        }

//        public async Task Delete()
//        {
//            Console.WriteLine(MenuStrings.MenuStrings.MATERIAL_TYPE_CHOOSE);
//            learnMaterialsType = (LearnMaterialsType)int.Parse(Console.ReadLine());
//            switch (learnMaterialsType)
//            {
//                case LearnMaterialsType.Article:
//                    Console.WriteLine("Please enter article name");
//                    string name = Console.ReadLine();
//                    var articles = await articleService.Find().FirstOrDefaultAsync(article => article.Name == name);
//                    int id = articles.Id;
//                    int choose = int.Parse(Console.ReadLine());
//                    if (choose == 0)
//                    {
//                        await articleService.Remove(id);
//                        Console.WriteLine("Article is deleted");
//                    }
//                    else if (choose == 1)
//                    {
//                        Console.WriteLine("Article is not deleted");
//                    }
//                    else
//                    {
//                        Console.WriteLine("Unsigned choise");
//                    }

//                    break;
//                case LearnMaterialsType.Book:
//                    Console.WriteLine("Please enter user email");
//                    name = Console.ReadLine();
//                    var books = await bookService.Find().FirstOrDefaultAsync(book => book.Name == name);
//                    id = books.Id;
//                    choose = int.Parse(Console.ReadLine());
//                    if (choose == 0)
//                    {
//                        await bookService.Remove(id);
//                        Console.WriteLine("Book is deleted");
//                    }
//                    else if (choose == 1)
//                    {
//                        Console.WriteLine("Book is not deleted");
//                    }
//                    else
//                    {
//                        Console.WriteLine("Unsigned choise");
//                    }

//                    break;
//                case LearnMaterialsType.Video:
//                    Console.WriteLine("Please enter user email");
//                    name = Console.ReadLine();
//                    var videos = await videoService.Find().FirstOrDefaultAsync(video => video.Name == name);
//                    id = videos.Id;
//                    choose = int.Parse(Console.ReadLine());
//                    if (choose == 0)
//                    {
//                        await videoService.Remove(id);
//                        Console.WriteLine("Your data is deleted");
//                    }
//                    else if (choose == 1)
//                    {
//                        Console.WriteLine("Your data is not deleted");
//                    }
//                    else
//                    {
//                        Console.WriteLine("Unsigned choise");
//                    }

//                    break;
//                default:
//                    break;
//            }
//        }

//        public async Task ShowArticles()
//        {
//            var articles = articleService.Find();
//            foreach (var article in articles)
//            {
//                Console.WriteLine("\nArticle name: " + article.Name);
//                Console.WriteLine("Resourse: " + article.Resource);
//                Console.WriteLine("Publication date: " + article.PublicationDate);
//            }
//        }

//        public async Task ShowBooks()
//        {
//            var books = bookService.Find();
//            foreach (var book in books)
//            {
//                Console.WriteLine("Book name: " + book.Name);
//                Console.WriteLine("Publication date: " + book.PublicationDate);
//                Console.WriteLine("Count of pages: " + book.PageCount);
//            }
//        }

//        public async Task ShowVideos()
//        {
//            var videos = videoService.Find();
//            foreach (var video in videos)
//            {
//                Console.WriteLine("Video name: " + video.Name);
//                Console.WriteLine("Quality: " + video.Quality);
//            }
//        }
//    }
//}
