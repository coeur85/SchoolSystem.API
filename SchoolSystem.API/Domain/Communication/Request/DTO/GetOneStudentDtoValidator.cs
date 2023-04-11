using FluentValidation;

namespace SchoolSystem.API.Domain.Communication.Request.DTO
{
    public class GetOneStudentDtoValidator : AbstractValidator<GetOneStudentDto>
    {
        public GetOneStudentDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
