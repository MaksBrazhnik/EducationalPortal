using Microsoft.AspNetCore.Mvc.Rendering;

namespace EducationalPortal.MVC.Models
{
    public class CourseSkillModel
    {
        public string CourseName { get; set; }

        public int CourseId { get; set; }

        public int SkillId { get; set; }

        public List<SelectListItem> SkillList { get; set; }
    }
}
