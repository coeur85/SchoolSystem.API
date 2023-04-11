using MediatR;
using SchoolSystem.API.Domain.Models.Students;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class CreateStudentCommand : IRequest<Student>
    {
        public string Name { get; init; }

        public CreateStudentCommand(string Name)
        {
            this.Name = Name;
        }
    }
}
