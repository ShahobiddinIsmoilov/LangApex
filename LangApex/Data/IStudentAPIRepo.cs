using LangApex.Models;

namespace LangApex.Data
{
    public interface IStudentAPIRepo
    {
        Task<IEnumerable<Student>> GetAllStudents();

        Task<Student> GetStudentByName(string name);

        Task CreateStudent(Student student);

        Task UpdateStudent(Student student);

        void DeleteStudent(Student student);

        public Task<bool> SaveChangesAsync();
    }
}
