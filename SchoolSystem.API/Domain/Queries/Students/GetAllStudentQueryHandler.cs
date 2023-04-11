using MediatR;
using SchoolSystem.API.Domain.Models;
using SchoolSystem.API.Domain.Repositories;
using System.Collections.Generic;

namespace SchoolSystem.API.Domain.Queries.Students
{
    public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQuery, List<Student>>
    {
        private readonly IStudentsRepository studentsRepository;

        public GetAllStudentQueryHandler(IStudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }
        public async Task<List<Student>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            var students = await this.studentsRepository.SelectAllAsync();
            return students;
        }
    }
}
