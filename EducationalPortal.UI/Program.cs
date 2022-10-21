//using EducationalPortal.BLL.ServicesImplementation;
//using EducationalPortal.DAL;
//using EducationalPortal.UI.EntityOperations;
//using EducationalPortal.UI.Enums;

namespace EducationalPortal.UI
{
   public class Program
    {
        public static async Task Main(string[] args)
        {
//            var userOperations = new UserOperations();
//            var courseOperations = new CourseOperations();
//            var materialOperations = new MaterialOperations();
//            var authorOperations = new AuthorOperations();
//            var skillOperations = new SkillOperations();
//            var bookAuthorOperations = new BookAuthorOperations();
//            var courseMaterialOperations = new CourseMaterialOperations();
//            var courseSkillOperations = new CourseSkillOperations();
//            var userCourseOperations = new UserCourseOperations();
//            var userMaterialOperations = new UserMaterialOperations();
//            var userSkillOperations = new UserSkillOperations();
//            var userAccountOperations = new UserAccountOperations();
//            EntryType entryType = new EntryType();
//            OperationsType operationsType = new OperationsType();
//            UserAccountOptions userAccountOptions = new UserAccountOptions();
//            CourseActivity courseActivity = new CourseActivity();
//            MaterialActivity materialActivity = new MaterialActivity();
//            SkillActivity skillActivity = new SkillActivity();
//            var loginService = new LoginService();

//            while (true)
//            {
//                Console.WriteLine(MenuStrings.MenuStrings.ENTRY_TYPE_CHOOSE);
//                entryType = (EntryType)int.Parse(Console.ReadLine());
//                switch (entryType)
//                {
//                    case EntryType.Registration:
//                        await userOperations.Add();
//                        break;
//                    case EntryType.Login:
//                        if ((loginService.Login(userOperations.UserEmail(), userOperations.UserPassword()).Result == true))
//                        {
//                            bool loginStatus = true;
//                            while (loginStatus)
//                            {
//                                Console.WriteLine(MenuStrings.MenuStrings.ACTIVITY_TYPE_CHOOSE);
//                                operationsType = (OperationsType)int.Parse(Console.ReadLine());
//                                switch (operationsType)
//                                {
//                                    case OperationsType.Courses:
//                                        bool inCourses = true;
//                                        while (inCourses)
//                                        {
//                                            Console.WriteLine(MenuStrings.MenuStrings.COURSE_ACTIVITY);
//                                            courseActivity = (CourseActivity)int.Parse(Console.ReadLine());
//                                            switch (courseActivity)
//                                            {
//                                                case CourseActivity.ShowCourses:
//                                                    await courseOperations.ShowCourses();
//                                                    break;
//                                                case CourseActivity.CreateCource:
//                                                    await courseOperations.Add();
//                                                    break;
//                                                case CourseActivity.AddMaterialToCourse:
//                                                    await courseMaterialOperations.Add();
//                                                    break;
//                                                case CourseActivity.AddSkillToCourse:
//                                                    await courseSkillOperations.Add();
//                                                    break;
//                                                case CourseActivity.AddCourseToUser:
//                                                    await userCourseOperations.Add(loginService.GetCurrentUserId());
//                                                    break;
//                                                case CourseActivity.DeleteCource:
//                                                    await courseOperations.Delete();
//                                                    break;
//                                                case CourseActivity.ExitToMainMenu:
//                                                    inCourses = false;
//                                                    break;
//                                                default:
//                                                    break;
//                                            }
//                                        }

//                                        break;
//                                    case OperationsType.Materials:
//                                        bool inMaterials = true;
//                                        while (inMaterials)
//                                        {
//                                            Console.WriteLine(MenuStrings.MenuStrings.MATERIAL_ACTIVITY);
//                                            materialActivity = (MaterialActivity)int.Parse(Console.ReadLine());
//                                            switch (materialActivity)
//                                            {
//                                                case MaterialActivity.ShowArticles:
//                                                    await materialOperations.ShowArticles();
//                                                    break;
//                                                case MaterialActivity.ShowBooks:
//                                                    await materialOperations.ShowBooks();
//                                                    break;
//                                                case MaterialActivity.ShowVideos:
//                                                    await materialOperations.ShowVideos();
//                                                    break;
//                                                case MaterialActivity.CreateMaterial:
//                                                    await materialOperations.Add();
//                                                    break;
//                                                case MaterialActivity.DeleteMaterial:
//                                                    await materialOperations.Delete();
//                                                    break;
//                                                case MaterialActivity.ExitToMainMenu:
//                                                    inMaterials = false;
//                                                    break;
//                                                default:
//                                                    break;
//                                            }
//                                        }

//                                        break;
//                                    case OperationsType.Skills:
//                                        bool inSkills = true;
//                                        while (inSkills)
//                                        {
//                                            Console.WriteLine(MenuStrings.MenuStrings.SKILL_ACTIVITY);
//                                            skillActivity = (SkillActivity)int.Parse(Console.ReadLine());
//                                            switch (skillActivity)
//                                            {
//                                                case SkillActivity.ShowSkills:
//                                                    await skillOperations.ShowSkills();
//                                                    break;
//                                                case SkillActivity.CreateSkill:
//                                                    await skillOperations.Add();
//                                                    break;
//                                                case SkillActivity.DeleteSkill:
//                                                    await skillOperations.Delete();
//                                                    break;
//                                                case SkillActivity.ExitToMainMenu:
//                                                    inSkills = false;
//                                                    break;
//                                                default:
//                                                    break;
//                                            }
//                                        }

//                                        break;
//                                    case OperationsType.UserAccount:
//                                        bool inUserAccount = true;
//                                        while (inUserAccount)
//                                        {
//                                            Console.WriteLine(MenuStrings.MenuStrings.USER_ACCOUNT_OPERATION);
//                                            userAccountOptions = (UserAccountOptions)int.Parse(Console.ReadLine());
//                                            switch (userAccountOptions)
//                                            {
//                                                case UserAccountOptions.ShowInfo:
//                                                    await userAccountOperations.ShowUserInformation(loginService.GetCurrentUserId());
//                                                    break;
//                                                case UserAccountOptions.ShowCourses:
//                                                    await userAccountOperations.ShowCourses(loginService.GetCurrentUserId());
//                                                    break;
//                                                case UserAccountOptions.ShowSkills:
//                                                    await userAccountOperations.ShowSkills(loginService.GetCurrentUserId());
//                                                    break;
//                                                case UserAccountOptions.ShowMaterials:
//                                                    await userAccountOperations.ShowUserMaterials(loginService.GetCurrentUserId());
//                                                    break;
//                                                case UserAccountOptions.ChangeUserInfo:
//                                                    await userAccountOperations.ChangeUserInformation(loginService.GetCurrentUserId());
//                                                    break;
//                                                case UserAccountOptions.Exit:
//                                                    inUserAccount = false;
//                                                    break;
//                                                default:
//                                                    break;
//                                            }
//                                        }

//                                        break;
//                                    case OperationsType.DeleteAccount:
//                                        break;
//                                    case OperationsType.Logout:
//                                        await loginService.Unlogin();
//                                        loginStatus = false;
//                                        break;
//                                    default:
//                                        break;
//                                }
//                            }
//                        }
//                        else
//                        {
//                            Console.WriteLine("Wrong password or email");
//                        }

//                        break;
//                    default:
//                        break;
//                }
//            }
        }
    }
}
