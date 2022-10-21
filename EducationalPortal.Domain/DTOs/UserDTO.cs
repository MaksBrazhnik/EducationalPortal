using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Enums;

namespace EducationalPortal.Domain.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FamilyName { get; set; }

        public string Email { get; set; }

        public UserRoles Role { get; set; } = UserRoles.User;

        public List<UserCourse> UserСourses { get; set; }

        public List<UserMaterial> UserMaterials { get; set; }

        public List<UserSkill> UserSkills { get; set; }
    }
}
