using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EducationalPortal.MVC.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter name")]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
