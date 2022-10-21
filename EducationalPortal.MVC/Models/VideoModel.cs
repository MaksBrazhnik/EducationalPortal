using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EducationalPortal.MVC.Models
{
    public class VideoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Length")]
        [Display(Name = "Length")]
        public double Length { get; set; }

        [Required(ErrorMessage = "Enter quality")]
        [Display(Name = "Quality")]
        public string Quality { get; set; }
    }
}
