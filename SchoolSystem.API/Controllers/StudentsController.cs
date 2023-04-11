using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using SchoolSystem.API.Domain.Commands.Students;
using SchoolSystem.API.Domain.Communication.Request.DTO;
using SchoolSystem.API.Domain.Models;
using SchoolSystem.API.Domain.Queries.Students;
using System.Runtime.CompilerServices;

namespace SchoolSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class StudentsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public StudentsController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<List<Student>> GetAllAsync()
            => await this.mediator.Send(new GetAllStudentQuery());
        [HttpPost("Create")]
        public async Task CreateStudentAsync(CreateStudentDto studentDto)
        {
            CreateStudentCommand studentCommand = this.mapper.Map<CreateStudentCommand>(studentDto);
            await this.mediator.Send(studentCommand);
        }

        [HttpGet("Get/{id}")]
        public async Task<Student> GetOneAsync(GetStudentDto studentDto)
        {
            GetOneStudentQuery studentQuery = this.mapper.Map<GetOneStudentQuery>(studentDto);
            return await this.mediator.Send(studentQuery);
        }

        [HttpDelete("Delete")]
        public async Task DeleteAsync(DeleteStudentDto studentDto)
        {
            DeleteStudentCommand studentCommand = this.mapper.Map<DeleteStudentCommand>(studentDto);
            await this.mediator.Send(studentCommand);

        }

        [HttpPut("Update")]
        public async Task UpdateAsync(UpdateStudentDto studentDto)
        {
            UpdateStudentCommand studentCommand = this.mapper.Map<UpdateStudentCommand>(studentDto);
            await this.mediator.Send(studentCommand);
        }

    }
}
