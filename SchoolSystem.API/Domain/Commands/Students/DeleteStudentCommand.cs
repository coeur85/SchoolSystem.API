using MediatR;
using SchoolSystem.API.Domain.Communication.Response;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class DeleteStudentCommand : IRequest<SchoolResponse>
    {
        public int Id { get; init; }

        public DeleteStudentCommand(int id)
        {
            this.Id = id;
        }
    }
}
