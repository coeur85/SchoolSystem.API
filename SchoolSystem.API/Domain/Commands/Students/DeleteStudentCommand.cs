using MediatR;
using SchoolSystem.API.Domain.Models.Students;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class DeleteStudentCommand : IRequest<Student>
    {
        public int Id { get; init; }

        public DeleteStudentCommand(int id)
        {
            this.Id = id;
        }
    }
}
