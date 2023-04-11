using FluentValidation;

namespace SchoolSystem.API.Domain.Communication.Request.DTO
{
    public class DeleteStudentDtoValidator : AbstractValidator<DeleteStudentDto>
    {
        public DeleteStudentDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);

        }
    }
}
