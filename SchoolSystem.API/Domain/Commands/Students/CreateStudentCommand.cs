using MediatR;
using SchoolSystem.API.Domain.Communication.Response;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class CreateStudentCommand : IRequest<SchoolResponse>
    {
        public string Name { get; init; }

        public CreateStudentCommand(string Name)
        {
            this.Name = Name;
        }
    }
}
