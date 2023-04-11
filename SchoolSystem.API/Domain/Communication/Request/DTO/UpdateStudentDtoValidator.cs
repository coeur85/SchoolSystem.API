using FluentValidation;

namespace SchoolSystem.API.Domain.Communication.Request.DTO
{
    public class UpdateStudentDtoValidator : AbstractValidator<UpdateStudentDto>
    {
        public UpdateStudentDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(100);
        }
    }
}
