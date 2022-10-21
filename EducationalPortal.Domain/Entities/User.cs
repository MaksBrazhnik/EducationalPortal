using EducationalPortal.Domain.Enums;

namespace EducationalPortal.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string FamilyName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserRoles Role { get; set; } = UserRoles.User;

        public List<UserCourse> UserСourses { get; set; }

        public List<UserMaterial> UserMaterials { get; set; }

        public List<UserSkill> UserSkills { get; set; }
    }
}
