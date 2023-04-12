using MediatR;
using SchoolSystem.API.Domain.Communication.Response;
using SchoolSystem.API.Domain.Models.Students;

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
