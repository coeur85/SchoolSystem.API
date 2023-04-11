using MediatR;
using SchoolSystem.API.Domain.Models.Students;

namespace SchoolSystem.API.Domain.Queries.Students
{
    public class GetAllStudentQuery : IRequest<List<Student>>
    {
    }
}
