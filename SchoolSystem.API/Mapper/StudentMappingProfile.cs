using SchoolSystem.API.Domain.Commands.Students;
using SchoolSystem.API.Domain.Communication.Request.DTO;
using SchoolSystem.API.Domain.Models.Students;
using SchoolSystem.API.Domain.Queries.Students;

namespace SchoolSystem.API.Mapper
{
    public class StudentMappingProfile : AutoMapper.Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<CreateStudentDto, CreateStudentCommand>();
            CreateMap<UpdateStudentDto, UpdateStudentCommand>();
            CreateMap<DeleteStudentDto, DeleteStudentCommand>();
            CreateMap<GetOneStudentDto, GetOneStudentQuery>();


            CreateMap<CreateStudentCommand, Student>();
            CreateMap<UpdateStudentCommand, Student>();
        }
    }
}
