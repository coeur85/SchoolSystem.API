using MediatR;
using SchoolSystem.API.Domain.Models;
using SchoolSystem.API.Domain.Repositories;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand, Student>
    {
        private readonly IStudentsRepository studentsRepository;

        public RemoveStudentCommandHandler(IStudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }
        public async Task<Student> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            Student deletedStudent = await this.studentsRepository.SelectOneAsync(request.Id);
            if (deletedStudent == null) { throw new Exception("Student Not found"); }

            await this.studentsRepository.DeleteAsync(deletedStudent.Id);

            return deletedStudent;
        }
    }
}
