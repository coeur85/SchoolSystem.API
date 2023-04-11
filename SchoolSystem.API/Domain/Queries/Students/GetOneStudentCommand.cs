using MediatR;
using SchoolSystem.API.Domain.Models;

namespace SchoolSystem.API.Domain.Queries.Students
{
    public class GetOneStudentCommand : IRequest<Student>
    {
        public int Id { get; init; }
        public GetOneStudentCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
