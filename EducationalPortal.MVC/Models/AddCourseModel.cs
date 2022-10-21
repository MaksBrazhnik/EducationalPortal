using System.ComponentModel.DataAnnotations;

namespace EducationalPortal.MVC.Models
{
    public class AddCourseModel
    {
        [Required(ErrorMessage = "Enter name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter description")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
