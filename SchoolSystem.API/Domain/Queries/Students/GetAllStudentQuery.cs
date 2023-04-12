using MediatR;
using SchoolSystem.API.Domain.Communication.Response;

namespace SchoolSystem.API.Domain.Queries.Students
{
    public class GetAllStudentQuery : IRequest<SchoolResponse>
    {
    }
}
