//using EducationalPortal.BLL.ServicesImplementation;
//using EducationalPortal.DAL.DBOperation;
//using EducationalPortal.DAL.RepositoryEFImplementation;
//using EducationalPortal.Domain.Entities;
//using EducationalPortal.UI.Enums;
//using Microsoft.EntityFrameworkCore;

//namespace EducationalPortal.UI.EntityOperations
//{
//    public class CourseSkillOperations
//    {
//        private CourseService courseService;
//        private SkillService skillService;
//        private CourseSkillService courseSkillService;
//        private SkillAdding skillAdding = new SkillAdding();

//        public CourseSkillOperations()
//        {
//            var educationalPortalContext = new EducationalPortalContext();
//            var courseRepository = new GenericRepository<Course>(educationalPortalContext);
//            var skillRepository = new GenericRepository<Skill>(educationalPortalContext);
//            var courseSkillRepository = new GenericRepository<CourseSkill>(educationalPortalContext);
//            courseService = new CourseService(courseRepository);
//            skillService = new SkillService(skillRepository);
//            courseSkillService = new CourseSkillService(courseSkillRepository);
//        }

//        public async Task Add()
//        {
//            var courseSkill = new CourseSkill();
//            Console.WriteLine("Enter course name");
//            var courseName = Console.ReadLine();
//            var course = await courseService.Find().FirstOrDefaultAsync(course => course.Name == courseName);
//            bool inAdding = true;
//            while (inAdding)
//            {
//                Console.WriteLine(MenuStrings.MenuStrings.SKILL_ADDING);
//                skillAdding = (SkillAdding)int.Parse(Console.ReadLine());
//                switch (skillAdding)
//                {
//                    case SkillAdding.AddSkill:
//                        Console.WriteLine("Enter skill name");
//                        var skillName = Console.ReadLine();
//                        var skill = await skillService.Find().FirstOrDefaultAsync(skill => skill.Name == skillName);
//                        courseSkill.CourseId = course.Id;
//                        courseSkill.SkillId = skill.Id;
//                        courseSkill.Course = course;
//                        courseSkill.Skill = skill;
//                        await courseSkillService.Add(courseSkill);
//                        break;
//                    case SkillAdding.Exit:
//                        inAdding = false;
//                        break;
//                }
//            }
//        }
//    }
//}
