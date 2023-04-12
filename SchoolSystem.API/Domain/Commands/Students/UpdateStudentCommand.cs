using MediatR;
using SchoolSystem.API.Domain.Communication.Response;
using SchoolSystem.API.Domain.Models.Students;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class UpdateStudentCommand : IRequest<SchoolResponse>
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public UpdateStudentCommand(int id, string Name)
        {
                this.Id = id;this.Name = Name;
        }
    }
}
