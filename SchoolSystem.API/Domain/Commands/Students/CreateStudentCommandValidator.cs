using FluentValidation;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3);
        }
    }
}
