using MediatR;
using SchoolSystem.API.Domain.Models;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class RemoveStudentCommand : IRequest<Student>
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public RemoveStudentCommand(int id, string name)
        {
                this.Id = id;this.Name = name;
        }
    }
}
