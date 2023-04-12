using MediatR;
using SchoolSystem.API.Domain.Communication.Response;

namespace SchoolSystem.API.Domain.Queries.Students
{
    public class GetOneStudentQuery : IRequest<SchoolResponse>
    {
        public int Id { get; init; }
        public GetOneStudentQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
