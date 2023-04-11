using FluentValidation;

namespace SchoolSystem.API.Domain.Communication.Request.DTO
{
    public class GetStudentDtoValidator : AbstractValidator<GetStudentDto>
    {
        public GetStudentDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
