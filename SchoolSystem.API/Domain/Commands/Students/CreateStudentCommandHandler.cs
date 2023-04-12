using AutoMapper;
using FluentValidation;
using MediatR;
using SchoolSystem.API.Domain.Communication.Response;
using SchoolSystem.API.Domain.Models.Students;
using SchoolSystem.API.Domain.Repositories;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, SchoolResponse>
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


        public async Task<SchoolResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var result = this.validator.Validate(request);
            if (!result.IsValid)
            {
                ErrorResponse errorResponse = new ErrorResponse(result.Errors);
                return errorResponse;
            }
            Student newStudent = this.mapper.Map<Student>(request);
            await this.studentsRepository.InsertAsync(newStudent);

            SuccessResponse successResponse = new SuccessResponse();
            return successResponse;
        }
    }
}
