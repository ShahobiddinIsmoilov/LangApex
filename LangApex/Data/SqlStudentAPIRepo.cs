using LangApex.Models;
using Microsoft.EntityFrameworkCore;

namespace LangApex.Data
{
    public class SqlStudentAPIRepo : IStudentAPIRepo
    {
        private readonly StudentContext _context;

        public SqlStudentAPIRepo(StudentContext context)
        {
            _context = context;
        }

        public async Task CreateStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            await _context.Students.AddAsync(student);
        }

        public void DeleteStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            _context.Students.Remove(student);
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByName(string name)
        {
            return await _context.Students.FirstOrDefaultAsync(student => student.Name == name);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public Task UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
