using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EducationalPortal.MVC.Models
{
    public class AddBookModel
    {
        [Required(ErrorMessage = "Enter name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter number of pages")]
        [Display(Name = "PageCount")]
        public int PageCount { get; set; }

        [Required(ErrorMessage = "Enter format")]
        [Display(Name = "Format")]
        public string Format { get; set; }

        [Required(ErrorMessage = "Choose publication date")]
        [Display(Name = "PublicationDate")]
        public DateTime PublicationDate { get; set; }
    }
}
