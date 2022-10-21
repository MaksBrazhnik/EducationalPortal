using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EducationalPortal.MVC.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Enter email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
