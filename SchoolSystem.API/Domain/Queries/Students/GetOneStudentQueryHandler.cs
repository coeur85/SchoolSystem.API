using MediatR;
using SchoolSystem.API.Domain.Models;
using SchoolSystem.API.Domain.Repositories;

namespace SchoolSystem.API.Domain.Queries.Students
{
    public class GetOneStudentQueryHandler : IRequestHandler<GetOneStudentQuery, Student>
    {
        private readonly IStudentsRepository studentsRepository;

        public GetOneStudentQueryHandler(IStudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }
        public async Task<Student> Handle(GetOneStudentQuery request, CancellationToken cancellationToken)
        {
           if (request.Id <= 0) { throw new Exception("invalid student id"); }
            Student student = await this.studentsRepository.SelectOneAsync(request.Id);
            return student;
        }
    }
}
