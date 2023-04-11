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

        public StudentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<List<Student>> GetAllAsync()
            => await this.mediator.Send(new GetAllStudentQuery());
        [HttpPost("Create")]
        public async Task CreateStudentAsync(CreateStudentDto studentDto)
            => await this.mediator.Send(new CreateStudentCommand(studentDto.Name));
        [HttpGet("Get/{id}")]
        public async Task<Student> GetOneAsync(GetStudentDto studentDto)
            => await this.mediator.Send(new GetOneStudentQuery(studentDto.Id));
        [HttpDelete("Delete")]
        public async Task DeleteAsync(DeleteStudentDto studentDto)
            => await this.mediator.Send(new DeleteStudentCommand(studentDto.Id));
        [HttpPut("Update")]
        public async Task UpdateAsync(UpdateStudentDto studentDto)
            => await this.mediator.Send(new UpdateStudentCommand(studentDto.Id, studentDto.Name));
    }
}
