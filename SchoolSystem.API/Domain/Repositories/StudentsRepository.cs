using SchoolSystem.API.Domain.Models;

namespace SchoolSystem.API.Domain.Repositories
{
    public class StudentsRepository : RepositoryManger<Student>, IStudentsRepository
    {
        public StudentsRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
