namespace EducationalPortal.BLL.Interfaces
{
    public interface IUserAccountOperations
    {
        public Task ChangeUserInformation(int userId);

        public Task ShowUserInformation(int userId);

        public Task ShowSkills(int userId);

        public Task ShowCourses(int userId);

        public Task ShowUserMaterials(int userId);
    }
}
