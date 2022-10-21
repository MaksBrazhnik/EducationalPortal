using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Interfaces.Repositories;

namespace EducationalPortal.DAL.RepositoryImplementation
{
    public class CourseRepository : ICourseRepository
    {
        public List<Course> courses = new List<Course>();

        public CourseRepository(List<Course> courses)
        {
            this.courses = courses;
        }

        public Course Create(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course is null");
            }

            var previousId = courses.LastOrDefault()?.Id ?? 0;
            course.Id = previousId++;
            courses.Add(course);
            return course;
        }

        public void Delete(int id)
        {
            courses.RemoveAll(p => p.Id == id);
        }

        public Course GetById(int id)
        {
            return (Course)courses.Find(p => p.Id == id);
        }

        public bool Update(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course");
            }

            int index = courses.FindIndex(p => p.Id == course.Id);
            if (index == -1)
            {
                return false;
            }

            courses.RemoveAt(index);
            courses.Add(course);
            return true;
        }
    }
}
