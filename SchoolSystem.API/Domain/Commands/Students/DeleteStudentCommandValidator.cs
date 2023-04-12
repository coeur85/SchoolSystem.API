using FluentValidation;

namespace SchoolSystem.API.Domain.Commands.Students
{
    public class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
    {
        public DeleteStudentCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
