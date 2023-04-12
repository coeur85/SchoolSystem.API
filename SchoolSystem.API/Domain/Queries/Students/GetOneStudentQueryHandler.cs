using FluentValidation;
using MediatR;
using SchoolSystem.API.Domain.Communication.Response;
using SchoolSystem.API.Domain.Models.Students;
using SchoolSystem.API.Domain.Models.Students.Exceptions;
using SchoolSystem.API.Domain.Repositories;

namespace SchoolSystem.API.Domain.Queries.Students
{
    public class GetOneStudentQueryHandler : IRequestHandler<GetOneStudentQuery, SchoolResponse>
    {
        private readonly IStudentsRepository studentsRepository;
        private readonly IValidator<GetOneStudentQuery> validator;

        public GetOneStudentQueryHandler(IStudentsRepository studentsRepository,
            IValidator<GetOneStudentQuery> validator)
        {
            this.studentsRepository = studentsRepository;
            this.validator = validator;
        }
        public async Task<SchoolResponse> Handle(GetOneStudentQuery request, CancellationToken cancellationToken)
        {
            var result = this.validator.Validate(request);

           if (! result.IsValid) { 
                ErrorResponse errorResponse =new ErrorResponse(result.Errors);
                return errorResponse;
            }
            Student student = await this.studentsRepository.SelectOneAsync(request.Id);
            SchoolResponse successResponse = new SuccessResponse(student);
            return successResponse;
        }
    }
}
