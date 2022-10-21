using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EducationalPortal.MVC.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter number of pages")]
        [Display(Name = "PageCount")]
        public int PageCount { get; set; }

        [Required(ErrorMessage = "Enter format")]
        [Display(Name = "Format")]
        public string Format { get; set; }

        [Required(ErrorMessage = "Enter publication date")]
        [Display(Name = "PublicationDate")]
        public DateTime PublicationDate { get; set; }

        [Required(ErrorMessage = "Choose author")]
        [Display(Name = "Authors")]
        public string Authors { get; set; }
    }
}
