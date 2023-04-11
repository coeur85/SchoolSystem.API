using MediatR;
using SchoolSystem.API.Domain.Models.Students;
using SchoolSystem.API.Domain.Repositories;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Student>
    {
        private readonly IStudentsRepository studentsRepository;
        public CreateStudentCommandHandler(IStudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }
        public async Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            Student newStundet = new Student();
            newStundet.Name = request.Name;

           await this.studentsRepository.InsertAsync(newStundet);
           return newStundet;

        }
    }
}
