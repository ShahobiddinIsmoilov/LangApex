using AutoMapper;
using LangApex.Dtos;
using LangApex.Models;

namespace LangApex.Profiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<StudentCreateDto, Student>();

            CreateMap<Student, StudentReadDto>();

            CreateMap<StudentUpdateDto, Student>();
        }
    }
}
