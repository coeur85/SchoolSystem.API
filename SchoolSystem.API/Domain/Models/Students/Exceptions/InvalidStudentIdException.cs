using SchoolSystem.API.Domain.Models.Exceptions;

namespace SchoolSystem.API.Domain.Models.Students.Exceptions
{
    public class InvalidStudentIdException : SchoolExceptions
    {
        public InvalidStudentIdException(int id)
            : base("Student ID", $"this number {id} is not valid student id")
        {

        }
    }
}
