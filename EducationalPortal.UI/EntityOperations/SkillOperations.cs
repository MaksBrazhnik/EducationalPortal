//using EducationalPortal.BLL.ServicesImplementation;
//using EducationalPortal.DAL.DBOperation;
//using EducationalPortal.DAL.RepositoryEFImplementation;
//using EducationalPortal.Domain.Entities;
//using EducationalPortal.Validation.Validation;
//using FluentValidation.Results;
//using Microsoft.EntityFrameworkCore;

//namespace EducationalPortal.UI.EntityOperations
//{
//    public class SkillOperations
//    {
//        private SkillService skillService;

//        public SkillOperations()
//        {
//            var educationalPortalContext = new EducationalPortalContext();
//            var skillRepository = new GenericRepository<Skill>(educationalPortalContext);
//            skillService = new SkillService(skillRepository);
//        }

//        public async Task Add()
//        {
//            var skill = new Skill();
//            var skillValidator = new SkillValidator();
//            Console.WriteLine("Enter skill name");
//            skill.Name = Console.ReadLine();
//            var result = skillValidator.Validate(skill);
//            if (!result.IsValid)
//            {
//                foreach (var failure in result.Errors)
//                {
//                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
//                }
//            }

//            await skillService.Add(skill);
//        }

//        public async Task Delete()
//        {
//            Console.WriteLine("Please enter article name");
//            string name = Console.ReadLine();
//            var skills = await skillService.Find().FirstOrDefaultAsync(skill => skill.Name == name);
//            int id = skills.Id;
//            int choose = int.Parse(Console.ReadLine());
//            if (choose == 0)
//            {
//                await skillService.Remove(id);
//                Console.WriteLine("Article is deleted");
//            }
//            else if (choose == 1)
//            {
//                Console.WriteLine("Article is not deleted");
//            }
//            else
//            {
//                Console.WriteLine("Unsigned choise");
//            }
//        }

//        public async Task ShowSkills()
//        {
//            var skills = skillService.Find();
//            foreach (var skill in skills)
//            {
//                Console.WriteLine("Skill name: " + skill.Name);
//            }
//        }
//    }
//}
