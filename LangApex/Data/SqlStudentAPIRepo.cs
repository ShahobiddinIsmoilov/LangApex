using LangApex.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LangApex.Data
{
    public class SqlStudentAPIRepo
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

        public async Task<IEnumerable<Student>> GetAllCommands()
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
    }
}
