using EducationalPortal.Domain.DTOs;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EducationalPortal.BLL.Interfaces
{
    public interface ICourseService
    {
        public Task<CourseDTO> GetCourseDTOByNameAsync(string name);

        public Task<bool> IsCreatedCourse(string name);

        public Task<CourseDTO> AddCourseAsync(AddCourseDTO addCourseDTO);

        public Task<CourseDTO> GetCourseDTOByIdAsync(int id);

        public Task RemoveCourseAsync(int id);

        public Task<CourseDTO> UpdateCourseAsync(CourseDTO updateCourseDTO);

        public Task<Course> GetCourseByIdAsync(int id);

        public Task<IEnumerable<CourseDTO>> GetCoursesDTOAsync();

        public Task<List<SelectListItem>> GetMaterialsSelectList();

        public Task<List<SelectListItem>> GetSkillsSelectList();

        public Task<Course> GetCourseByNameAsync(string name);

        public Task<Course> GetFilledCourseByIdAsync(int id);

        public Task<CourseListDTO> GetAllCoursesAsync(int page, SortState sortOrder);
    }
}
