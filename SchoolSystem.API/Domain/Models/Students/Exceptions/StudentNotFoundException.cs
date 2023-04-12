using SchoolSystem.API.Domain.Models.Exceptions;

namespace SchoolSystem.API.Domain.Models.Students.Exceptions
{
    public class StudentNotFoundException : SchoolExceptions
    {
        public StudentNotFoundException()
            : base("StudentModel", "student was not found!")
        {

        }
    }
}
