using FluentValidation;
using SchoolSystem.API.Domain.Models.Students;
using SchoolSystem.API.Domain.Repositories;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        private readonly IStudentsRepository studentsRepository;

        public UpdateStudentCommandValidator(IStudentsRepository studentsRepository)
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(100);
            this.studentsRepository = studentsRepository;
            RuleFor(x => x.Id).MustAsync(async (id, _) => {
                Student dbStudent = await this.studentsRepository.SelectOneAsync(id);
                return dbStudent != null;
            
            }).WithMessage("This student id does not exisits");
        }
    }
}
