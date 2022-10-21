using System.ComponentModel.DataAnnotations;

namespace EducationalPortal.MVC.Models
{
    public class AddAuthorModel
    {
        [Required(ErrorMessage = "Enter name")]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
