using System.ComponentModel.DataAnnotations;

namespace EducationalPortal.MVC.Models
{
    public class AddVideoModel
    {
        [Required(ErrorMessage = "Enter name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter length")]
        [Display(Name = "Length")]
        public double Length { get; set; }

        [Required(ErrorMessage = "Enter quality")]
        [Display(Name = "Quality")]
        public string Quality { get; set; }
    }
}
