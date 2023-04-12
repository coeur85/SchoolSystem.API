using AutoMapper;
using FluentValidation;
using MediatR;
using SchoolSystem.API.Domain.Communication.Response;
using SchoolSystem.API.Domain.Models.Students;
using SchoolSystem.API.Domain.Repositories;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, SchoolResponse>
    {
        private readonly IStudentsRepository studentsRepository;
        private readonly IMapper mapper;
        private readonly IValidator<UpdateStudentCommand> validator;

        public UpdateStudentCommandHandler(IStudentsRepository studentsRepository, IMapper mapper
            , IValidator<UpdateStudentCommand> validator)
        {
            this.studentsRepository = studentsRepository;
            this.mapper = mapper;
            this.validator = validator;
        }
        public async Task<SchoolResponse> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await this.validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                ErrorResponse errorResponse = new ErrorResponse(result.Errors);
                return errorResponse;
            }

            Student studentToBeUpdated = this.mapper.Map<Student>(request);
            Student dbStudent = await this.studentsRepository.SelectOneAsync(request.Id);

            dbStudent.Name = studentToBeUpdated.Name;
            await studentsRepository.UpdateAsync(dbStudent);
            SuccessResponse successResponse = new SuccessResponse(dbStudent);
            return successResponse;
        }
    }
}
