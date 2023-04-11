using MediatR;
using SchoolSystem.API.Domain.Models;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class UpdateStudentCommand : IRequest<Student>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UpdateStudentCommand(int id, string Name)
        {
                this.Id = id;this.Name = Name;
        }
    }
}
