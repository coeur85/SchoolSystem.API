using MediatR;
using SchoolSystem.API.Domain.Models;
using SchoolSystem.API.Domain.Repositories;
using System.Data.SqlTypes;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Student>
    {
        private readonly IStudentsRepository studentsRepository;

        public UpdateStudentCommandHandler(IStudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }
        public async Task<Student> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            Student studentToBeUpdated = new Student() { Id = request.Id , Name = request.Name };
            Student dbStudent = await this.studentsRepository.SelectOneAsync(request.Id);
            if (dbStudent == null) { throw new Exception("Student Not Found"); }
            if(dbStudent.Name == studentToBeUpdated.Name) { throw new Exception($" student name has not been changed"); }


            await  studentsRepository.UpdateAsync(studentToBeUpdated);
            return studentToBeUpdated;
        }
    }
}
