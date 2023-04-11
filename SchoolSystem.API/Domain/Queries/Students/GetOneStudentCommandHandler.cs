using MediatR;
using SchoolSystem.API.Domain.Models;
using SchoolSystem.API.Domain.Repositories;

namespace SchoolSystem.API.Domain.Queries.Students
{
    public class GetOneStudentCommandHandler : IRequestHandler<GetOneStudentCommand, Student>
    {
        private readonly StudentsRepository studentsRepository;

        public GetOneStudentCommandHandler(StudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }
        public async Task<Student> Handle(GetOneStudentCommand request, CancellationToken cancellationToken)
        {
           if (request.Id <= 0) { throw new Exception("invalid student id"); }
            Student student = await this.studentsRepository.SelectOneAsync(request.Id);
            return student;
        }
    }
}
