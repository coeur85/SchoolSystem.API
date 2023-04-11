using MediatR;
using SchoolSystem.API.Domain.Models;
using SchoolSystem.API.Domain.Repositories;

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
            Student updateStudent = new Student() { Id = request.Id , Name = request.Name };
            await  studentsRepository.UpdateAsync(updateStudent);
            return updateStudent;
        }
    }
}
