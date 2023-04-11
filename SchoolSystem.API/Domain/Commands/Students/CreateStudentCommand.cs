using MediatR;
using SchoolSystem.API.Domain.Models;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class CreateStudentCommand : IRequest<Student>
    {
        public string Name { get; set; }

        public CreateStudentCommand(string Name)
        {
            this.Name = Name;
        }
    }
}
