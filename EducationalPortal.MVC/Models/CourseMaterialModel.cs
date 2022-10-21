using EducationalPortal.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EducationalPortal.MVC.Models
{
    public class CourseMaterialModel
    {
        public string CourseName { get; set; }

        public int CourseId { get; set; }

        public int MaterialId { get; set; }

        public List<SelectListItem> MaterialList { get; set; }
    }
}