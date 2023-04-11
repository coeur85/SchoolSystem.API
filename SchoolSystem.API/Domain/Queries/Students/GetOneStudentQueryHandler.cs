using FluentValidation;
using MediatR;
using SchoolSystem.API.Domain.Communication.Reponse;
using SchoolSystem.API.Domain.Models.Students;
using SchoolSystem.API.Domain.Models.Students.Exceptions;
using SchoolSystem.API.Domain.Repositories;

namespace SchoolSystem.API.Domain.Queries.Students
{
    public class GetOneStudentQueryHandler : IRequestHandler<GetOneStudentQuery, SchoolResponse<Student>>
    {
        private readonly IStudentsRepository studentsRepository;
        private readonly IValidator<GetOneStudentQuery> validator;

        public GetOneStudentQueryHandler(IStudentsRepository studentsRepository,
            IValidator<GetOneStudentQuery> validator)
        {
            this.studentsRepository = studentsRepository;
            this.validator = validator;
        }
        public async Task<SchoolResponse<Student>> Handle(GetOneStudentQuery request, CancellationToken cancellationToken)
        {
            var result = this.validator.Validate(request);

           if (! result.IsValid) { 
                ErrorResponse<Student> errorResponse =new ErrorResponse<Student>();
                foreach (var ex in result.Errors)
                {
                    errorResponse.AddError(ex.PropertyName, ex.ErrorMessage);
                }
                return errorResponse;
            }
            Student student = await this.studentsRepository.SelectOneAsync(request.Id);
            SuccessResponse<Student> successResponse = new SuccessResponse<Student>();
            successResponse.Data = student;
            return successResponse;
        }
    }
}
