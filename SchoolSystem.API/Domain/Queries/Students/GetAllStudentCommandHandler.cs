using MediatR;
using SchoolSystem.API.Domain.Models;
using SchoolSystem.API.Domain.Repositories;
using System.Collections.Generic;

namespace SchoolSystem.API.Domain.Queries.Students
{
    public class GetAllStudentCommandHandler : IRequestHandler<GetAllStudentCommand, List<Student>>
    {
        private readonly StudentsRepository studentsRepository;

        public GetAllStudentCommandHandler(StudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }
        public async Task<List<Student>> Handle(GetAllStudentCommand request, CancellationToken cancellationToken)
        {
            var students = await this.studentsRepository.SelectAllAsync();
            return students;
        }
    }
}
