using SchoolSystem.API.Domain.Models.Students;

namespace SchoolSystem.API.Domain.Repositories
{
    public class StudentsRepository : RepositoryManger<Student>, IStudentsRepository
    {
        public StudentsRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
