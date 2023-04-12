using MediatR;
using SchoolSystem.API.Domain.Communication.Response;
using SchoolSystem.API.Domain.Models.Students;
using SchoolSystem.API.Domain.Repositories;
using System.Collections.Generic;

namespace SchoolSystem.API.Domain.Queries.Students
{
    public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQuery, SchoolResponse>
    {
        private readonly IStudentsRepository studentsRepository;

        public GetAllStudentQueryHandler(IStudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }
        public async Task<SchoolResponse> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            var students = await this.studentsRepository.SelectAllAsync();
            SuccessResponse response = new SuccessResponse(students);
            return response;
        }
    }
}
