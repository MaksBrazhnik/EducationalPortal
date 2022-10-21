using EducationalPortal.Domain.Entities;
using System.Text;
using System.Text.Json;

namespace EducationalPortal.DAL.JSONOperation
{
    public class DeserializationJSON
    {
        public List<Article> ReadArticlesFromFile()
        {
            string path = @"D:\Nix\Educational Portal\Articles.json";
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = Encoding.Default.GetBytes("[]");
                    fs.Write(info, 0, info.Length);
                }

                return new List<Article>();
            }
            else
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] output = new byte[fs.Length];
                    fs.Read(output, 0, output.Length);
                    string jsonString = Encoding.Default.GetString(output);
                    return JsonSerializer.Deserialize<List<Article>>(jsonString)!;
                }
            }
        }

        public List<Book> ReadBooksFromFile()
        {
            string path = @"D:\Nix\Educational Portal\Books.json";
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = Encoding.Default.GetBytes("[]");
                    fs.Write(info, 0, info.Length);
                }

                return new List<Book>();
            }
            else
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] output = new byte[fs.Length];
                    fs.Read(output, 0, output.Length);
                    string jsonString = Encoding.Default.GetString(output);
                    return JsonSerializer.Deserialize<List<Book>>(jsonString)!;
                }
            }
        }

        public List<Video> ReadVideosFromFile()
        {
            string path = @"D:\Nix\Educational Portal\Videos.json";
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = Encoding.Default.GetBytes("[]");
                    fs.Write(info, 0, info.Length);
                }

                return new List<Video>();
            }
            else
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] output = new byte[fs.Length];
                    fs.Read(output, 0, output.Length);
                    string jsonString = Encoding.Default.GetString(output);
                    return JsonSerializer.Deserialize<List<Video>>(jsonString)!;
                }
            }
        }

        public List<User> ReadUsersFromFile()
        {
            string path = @"D:\Nix\Educational Portal\Users.json";
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = Encoding.Default.GetBytes("[]");
                    fs.Write(info, 0, info.Length);
                }

                return new List<User>();
            }
            else
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] output = new byte[fs.Length];
                    fs.Read(output, 0, output.Length);
                    string jsonString = Encoding.Default.GetString(output);
                    return JsonSerializer.Deserialize<List<User>>(jsonString)!;
                }
            }
        }

        public List<Skill> ReadSkillsFromFile()
        {
            string path = @"D:\Nix\Educational Portal\Skills.json";
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = Encoding.Default.GetBytes("[]");
                    fs.Write(info, 0, info.Length);
                }

                return new List<Skill>();
            }
            else
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] output = new byte[fs.Length];
                    fs.Read(output, 0, output.Length);
                    string jsonString = Encoding.Default.GetString(output);
                    return JsonSerializer.Deserialize<List<Skill>>(jsonString)!;
                }
            }
        }

        public List<Course> ReadCoursesFromFile()
        {
            string path = @"D:\Nix\Educational Portal\Courses.json";
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = Encoding.Default.GetBytes("[]");
                    fs.Write(info, 0, info.Length);
                }

                return new List<Course>();
            }
            else
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] output = new byte[fs.Length];
                    fs.Read(output, 0, output.Length);
                    string jsonString = Encoding.Default.GetString(output);
                    return JsonSerializer.Deserialize<List<Course>>(jsonString)!;
                }
            }
        }

        public List<UserCourse> ReadUserCoursesFromFile()
        {
            string path = @"D:\Nix\Educational Portal.json";
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = Encoding.Default.GetBytes("[]");
                    fs.Write(info, 0, info.Length);
                }

                return new List<UserCourse>();
            }
            else
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] output = new byte[fs.Length];
                    fs.Read(output, 0, output.Length);
                    string jsonString = Encoding.Default.GetString(output);
                    return JsonSerializer.Deserialize<List<UserCourse>>(jsonString)!;
                }
            }
        }

        public List<UserMaterial> ReadUserMaterialsFromFile()
        {
            string path = @"D:\Nix\Educational Portal.json";
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = Encoding.Default.GetBytes("[]");
                    fs.Write(info, 0, info.Length);
                }

                return new List<UserMaterial>();
            }
            else
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] output = new byte[fs.Length];
                    fs.Read(output, 0, output.Length);
                    string jsonString = Encoding.Default.GetString(output);
                    return JsonSerializer.Deserialize<List<UserMaterial>>(jsonString)!;
                }
            }
        }

        public List<UserSkill> ReadUserSkillsFromFile()
        {
            string path = @"D:\Nix\Educational Portal\UserSkills.json";
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = Encoding.Default.GetBytes("[]");
                    fs.Write(info, 0, info.Length);
                }

                return new List<UserSkill>();
            }
            else
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] output = new byte[fs.Length];
                    fs.Read(output, 0, output.Length);
                    string jsonString = Encoding.Default.GetString(output);
                    return JsonSerializer.Deserialize<List<UserSkill>>(jsonString)!;
                }
            }
        }

        public List<CourseSkill> ReadCoursesSkillFromFile()
        {
            string path = @"D:\Nix\Educational Portal\CourseSkill.json";
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = Encoding.Default.GetBytes("[]");
                    fs.Write(info, 0, info.Length);
                }

                return new List<CourseSkill>();
            }
            else
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] output = new byte[fs.Length];
                    fs.Read(output, 0, output.Length);
                    string jsonString = Encoding.Default.GetString(output);
                    return JsonSerializer.Deserialize<List<CourseSkill>>(jsonString)!;
                }
            }
        }

        public List<Author> ReadAuthorsFromFile()
        {
            string path = @"D:\Nix\Educational Portal\Articles.json";
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = Encoding.Default.GetBytes("[]");
                    fs.Write(info, 0, info.Length);
                }

                return new List<Author>();
            }
            else
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] output = new byte[fs.Length];
                    fs.Read(output, 0, output.Length);
                    string jsonString = Encoding.Default.GetString(output);
                    return JsonSerializer.Deserialize<List<Author>>(jsonString)!;
                }
            }
        }
    }
}
