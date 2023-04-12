using MediatR;
using SchoolSystem.API.Domain.Communication.Reponse;
using SchoolSystem.API.Domain.Models.Students;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class CreateStudentCommand : IRequest<SchoolResponse<Student>>
    {
        public string Name { get; init; }

        public CreateStudentCommand(string Name)
        {
            this.Name = Name;
        }
    }
}
