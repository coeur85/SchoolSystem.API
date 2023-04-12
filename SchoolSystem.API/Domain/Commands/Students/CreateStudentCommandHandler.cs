﻿using AutoMapper;
using FluentValidation;
using MediatR;
using SchoolSystem.API.Domain.Communication.Reponse;
using SchoolSystem.API.Domain.Models.Students;
using SchoolSystem.API.Domain.Repositories;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, SchoolResponse<Student>>
    {
        private readonly IStudentsRepository studentsRepository;
        private readonly IValidator<CreateStudentCommand> validator;
        private readonly IMapper mapper;

        public CreateStudentCommandHandler(IStudentsRepository studentsRepository
            , IValidator<CreateStudentCommand> validator, IMapper mapper)
        {
            this.studentsRepository = studentsRepository;
            this.validator = validator;
            this.mapper = mapper;
        }
       

        public async Task<SchoolResponse<Student>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var result = this.validator.Validate(request);
            if(!result.IsValid)
            {
                ErrorResponse<Student> errorResponse = new ErrorResponse<Student>();
                foreach (var ex in result.Errors)
                    errorResponse.AddError(ex.PropertyName, ex.ErrorMessage);

                return errorResponse;
            }
            Student newStudent = this.mapper.Map<Student>(request);
            await this.studentsRepository.InsertAsync(newStudent);

           SuccessResponse<Student> successResponse = new SuccessResponse<Student>();  
            return successResponse;
        }
    }
}
