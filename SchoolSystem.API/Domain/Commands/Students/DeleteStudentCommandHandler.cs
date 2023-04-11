using MediatR;
using SchoolSystem.API.Domain.Models;
using SchoolSystem.API.Domain.Repositories;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Student>
    {
        private readonly IStudentsRepository studentsRepository;

        public DeleteStudentCommandHandler(IStudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }
        public async Task<Student> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            Student deletedStudent = await this.studentsRepository.SelectOneAsync(request.Id);
            if (deletedStudent == null) { throw new Exception("Student Not found"); }

            await this.studentsRepository.DeleteAsync(deletedStudent);

            return deletedStudent;
        }
    }
}
