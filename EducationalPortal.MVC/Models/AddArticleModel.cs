using System.ComponentModel.DataAnnotations;

namespace EducationalPortal.MVC.Models
{
    public class AddArticleModel
    {
        [Required(ErrorMessage = "Enter name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Choose publication date")]
        [Display(Name = "PublicationDate")]
        public DateTime PublicationDate { get; set; }

        [Required(ErrorMessage = "Enter resourse")]
        [Display(Name = "Resource")]
        public string Resource { get; set; }
    }
}
