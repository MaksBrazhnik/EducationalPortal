using EducationalPortal.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace EducationalPortal.MVC.Models
{
    public class UserUpdateModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter name")]
        [RegularExpression(@"^\s*[A-ZА-Я][a-zа-я]+('[a-zа-я]+|-[A-ZА-Я][a-zа-я]+)?\s*$",
            ErrorMessage = "Name mast contain letters only")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter familyname")]
        [RegularExpression(@"^\s*[A-ZА-Я][a-zа-я]+('[a-zа-я]+|-[A-ZА-Я][a-zа-я]+)?\s*$",
            ErrorMessage = "Familyname mast contain letters only")]
        [Display(Name = "FamilyName")]
        public string FamilyName { get; set; }

        [EmailAddress(ErrorMessage = "EmailError")]
        [Required(ErrorMessage = "Enter Email")]
        [RegularExpression(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$",
            ErrorMessage = "Email is not correct")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public List<UserCourse> UserСourses { get; set; }

        public List<UserMaterial> UserMaterials { get; set; }

        public List<UserSkill> UserSkills { get; set; }
    }
}
