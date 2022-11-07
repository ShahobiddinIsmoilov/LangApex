using AutoMapper;
using LangApex.Data;
using LangApex.Dtos;
using LangApex.Models;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LangApex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentAPIRepo _repository;

        private readonly IMapper _mapper;

        public StudentsController(IStudentAPIRepo repository, IMapper mapper)        {
            _repository = repository;

            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentCreateDto studentCreatedDto)
        {
            var studentModel = _mapper.Map<Student>(studentCreatedDto);

            await _repository.CreateStudent(studentModel);

            await _repository.SaveChangesAsync();

            var commandReadDto = _mapper.Map<StudentReadDto>(studentModel);

            return Created("", studentModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _repository.GetAllStudents();

            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(students));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentByName(string name)
        {
            var student = await _repository.GetStudentByName(name);

            if (student == null)
                return NotFound();

            return Ok(_mapper.Map<StudentReadDto>(student));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(string name)
        {
            var studentModelFromRepo = await _repository.GetStudentByName(name);

            if (studentModelFromRepo == null)
                return NotFound();

            _repository.DeleteStudent(studentModelFromRepo);

            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(string name, StudentUpdateDto updateDto)
        {
            var studentModelFromRepo = await _repository.GetStudentByName(name);

            if (studentModelFromRepo == null)
                return NotFound();

            _mapper.Map(updateDto, studentModelFromRepo);

            await _repository.UpdateStudent(studentModelFromRepo);

            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}
