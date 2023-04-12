using FluentValidation;
using SchoolSystem.API.Domain.Models.Students;
using SchoolSystem.API.Domain.Repositories;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
    {
        private readonly IStudentsRepository studentsRepository;

        public DeleteStudentCommandValidator(IStudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Id).MustAsync(async (id, _) =>
            {
                Student dbStudent = await this.studentsRepository.SelectOneAsync(id);
                return dbStudent != null;

            }).WithMessage("this student id is out of range");

        }
        //public DeleteStudentCommandValidator()
        //{
        //   // this.studentsRepository = studentsRepository;
        //    RuleFor(x => x.Id).GreaterThan(0);


        //}
    }
}
