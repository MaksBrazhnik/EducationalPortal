using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EducationalPortal.MVC.Models
{
    public class CourseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter description")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
