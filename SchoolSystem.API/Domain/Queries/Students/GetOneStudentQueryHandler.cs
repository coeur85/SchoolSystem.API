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

        public GetOneStudentQueryHandler(IStudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }
        public async Task<SchoolResponse<Student>> Handle(GetOneStudentQuery request, CancellationToken cancellationToken)
        {
           if (request.Id <= 0) { 
                ErrorResponse<Student> errorResponse =new ErrorResponse<Student>();
                errorResponse.AddError(new InvalidStudentIdException(request.Id));
                return errorResponse;
            }
            Student student = await this.studentsRepository.SelectOneAsync(request.Id);
            SuccessResponse<Student> successResponse = new SuccessResponse<Student>();
            successResponse.Data = student;
            return successResponse;
        }
    }
}
