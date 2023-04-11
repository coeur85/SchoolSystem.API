using FluentValidation;

namespace SchoolSystem.API.Domain.Queries.Students
{
    public class GetOneStudentQueryValidator : AbstractValidator<GetOneStudentQuery>
    {
        public GetOneStudentQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
