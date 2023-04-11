using MediatR;
using SchoolSystem.API.Domain.Models;

namespace SchoolSystem.API.Domain.Queries.Students
{
    public class GetOneStudentQuery : IRequest<Student>
    {
        public int Id { get; init; }
        public GetOneStudentQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
