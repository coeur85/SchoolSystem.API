﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.API.Domain.Commands.Students;
using SchoolSystem.API.Domain.Communication.Request.DTO;
using SchoolSystem.API.Domain.Communication.Response;
using SchoolSystem.API.Domain.Queries.Students;

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
        public async Task<SchoolResponse> GetAllAsync()
            => await this.mediator.Send(new GetAllStudentQuery());
        [HttpPost("Create")]
        public async Task<SchoolResponse> CreateStudentAsync(CreateStudentDto studentDto)
        {
            CreateStudentCommand studentCommand = this.mapper.Map<CreateStudentCommand>(studentDto);
            return await this.mediator.Send(studentCommand);
        }

        [HttpGet("Get/{id}")]
        public async Task<SchoolResponse> GetOneAsync(int id)
        {
            return await this.mediator.Send(new GetOneStudentQuery(id));
        }

        [HttpDelete("Delete")]
        public async Task<SchoolResponse> DeleteAsync(DeleteStudentDto studentDto)
        {
            DeleteStudentCommand studentCommand = this.mapper.Map<DeleteStudentCommand>(studentDto);
            return await this.mediator.Send(studentCommand);

        }

        [HttpPut("Update")]
        public async Task<SchoolResponse> UpdateAsync(UpdateStudentDto studentDto)
        {
            UpdateStudentCommand studentCommand = this.mapper.Map<UpdateStudentCommand>(studentDto);
            return await this.mediator.Send(studentCommand);
        }

    }
}
