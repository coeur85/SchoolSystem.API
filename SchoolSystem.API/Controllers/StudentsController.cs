using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<List<Student>> GetAll()
            => await this.mediator.Send(new GetAllStudentQuery());
        [HttpPost("Create")]
        public async Task CreateStudent(CreateStudentDto studentDto)
            => await this.mediator.Send(new CreateStudentCommand(studentDto.Name));
    }
}
