using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Enums;

namespace EducationalPortal.Domain.Interfaces.Services
{
    public interface ICourseMaterialService
    {
        public Task<int> AddMaterialToCourseAsync(int courseId, int materialId);

        public Task RemoveCourseMaterialAsync(int id);

        public Task<CourseMaterial> GetCourseMaterialByIdAsync(int id);

        public Task<IEnumerable<LearnMaterial>> GetMaterialsAsync(int courseId);

        public Task<CourseMaterialListDTO> GetAllCourseMaterialsAsync(int courseId, int page, SortState sortOrder);
    }
}
