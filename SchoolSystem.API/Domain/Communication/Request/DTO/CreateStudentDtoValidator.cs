using FluentValidation;

namespace SchoolSystem.API.Domain.Communication.Request.DTO
{
    public class CreateStudentDtoValidator : AbstractValidator<CreateStudentDto>
    {
        public CreateStudentDtoValidator() {

            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3);
        
        }
    }
}
