using MediatR;
using SchoolSystem.API.Domain.Communication.Response;
using SchoolSystem.API.Domain.Models.Students;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class DeleteStudentCommand : IRequest<SchoolResponse<Student>>
    {
        public int Id { get; init; }

        public DeleteStudentCommand(int id)
        {
            this.Id = id;
        }
    }
}
