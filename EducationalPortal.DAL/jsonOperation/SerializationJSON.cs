using EducationalPortal.Domain.Entities;
using System.Text;
using System.Text.Json;

namespace EducationalPortal.DAL.JSONOperation
{
    public class SerializationJSON
    {
        public void SerializeBooks(List<Book> books)
        {
            string path = @"D:\Nix\Educational Portal\Books.json";
            string jsonString = JsonSerializer.Serialize(books);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] info = Encoding.Default.GetBytes(jsonString);
                fs.Write(info, 0, info.Length);
            }
        }

        public void SerializeArticles(List<Article> articles)
        {
            string path = @"D:\Nix\Educational Portal\Articles.json";
            string jsonString = JsonSerializer.Serialize(articles);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] info = Encoding.Default.GetBytes(jsonString);
                fs.Write(info, 0, info.Length);
            }
        }

        public void SerializeVideos(List<Video> videos)
        {
            string path = @"D:\Nix\Educational Portal\Videos.json";
            string jsonString = JsonSerializer.Serialize(videos);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] info = Encoding.Default.GetBytes(jsonString);
                fs.Write(info, 0, info.Length);
            }
        }

        public void SerializeSkills(List<Skill> skills)
        {
            string path = @"D:\Nix\Educational Portal\Skills.json";
            string jsonString = JsonSerializer.Serialize(skills);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] info = Encoding.Default.GetBytes(jsonString);
                fs.Write(info, 0, info.Length);
            }
        }

        public void SerializeUsers(List<User> users)
        {
            string path = @"D:\Nix\Educational Portal\Users.json";
            string jsonString = JsonSerializer.Serialize(users);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] info = Encoding.Default.GetBytes(jsonString);
                fs.Write(info, 0, info.Length);
            }
        }

        public void SerializeCourses(List<Course> courses)
        {
            string path = @"D:\Nix\Educational Portal\Courses.json";
            string jsonString = JsonSerializer.Serialize(courses);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] info = Encoding.Default.GetBytes(jsonString);
                fs.Write(info, 0, info.Length);
            }
        }

        public void SerializeUserCourses(List<UserCourse> userCourses)
        {
            string path = @"D:\Nix\Educational Portal\UserCourses.json";
            string jsonString = JsonSerializer.Serialize(userCourses);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] info = Encoding.Default.GetBytes(jsonString);
                fs.Write(info, 0, info.Length);
            }
        }

        public void SerializeUserMaterials(List<UserMaterial> userMaterials)
        {
            string path = @"D:\Nix\Educational Portal\UserMaterials.json";
            string jsonString = JsonSerializer.Serialize(userMaterials);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] info = Encoding.Default.GetBytes(jsonString);
                fs.Write(info, 0, info.Length);
            }
        }

        public void SerializeUserSkill(List<UserSkill> userSkills)
        {
            string path = @"D:\Nix\Educational Portal\UserSkills.json";
            string jsonString = JsonSerializer.Serialize(userSkills);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] info = Encoding.Default.GetBytes(jsonString);
                fs.Write(info, 0, info.Length);
            }
        }

        public void SerializeCourseSkill(List<CourseSkill> courseSkills)
        {
            string path = @"D:\Nix\Educational Portal\CourseSkills.json";
            string jsonString = JsonSerializer.Serialize(courseSkills);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] info = Encoding.Default.GetBytes(jsonString);
                fs.Write(info, 0, info.Length);
            }
        }

        public void SerializeAuthors(List<Author> authors)
        {
            string path = @"D:\Nix\Educational Portal\Authors.json";
            string jsonString = JsonSerializer.Serialize(authors);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] info = Encoding.Default.GetBytes(jsonString);
                fs.Write(info, 0, info.Length);
            }
        }
    }
}
