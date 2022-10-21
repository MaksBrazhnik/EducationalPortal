using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EducationalPortal.MVC.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter publication date")]
        [Display(Name = "PublicationDate")]
        public DateTime PublicationDate { get; set; }

        [Required(ErrorMessage = "Enter resourse")]
        [Display(Name = "Resource")]
        public string Resource { get; set; }
    }
}
