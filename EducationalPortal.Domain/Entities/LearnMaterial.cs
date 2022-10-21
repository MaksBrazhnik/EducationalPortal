using EducationalPortal.Domain.Enums;

namespace EducationalPortal.Domain.Entities
{
    public abstract class LearnMaterial : BaseEntity
    {
        public string Name { get; set; }

        public LearnMaterialsType LearnMaterialsType { get; set; }

        public List<UserMaterial> UserMaterials { get; set; }
    }
}
