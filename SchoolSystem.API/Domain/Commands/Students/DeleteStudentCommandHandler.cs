using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SchoolSystem.API.Domain.Communication.Response;
using SchoolSystem.API.Domain.Models.Students;
using SchoolSystem.API.Domain.Repositories;


namespace SchoolSystem.API.Domain.Commands.Students
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand,SchoolResponse<Student>>
    {
        private readonly IStudentsRepository studentsRepository;
        private readonly IValidator<DeleteStudentCommand> validator;

        public DeleteStudentCommandHandler(IStudentsRepository studentsRepository
            , IValidator<DeleteStudentCommand> validator)
        {
            this.studentsRepository = studentsRepository;
            this.validator = validator;
        }
        public async Task<SchoolResponse<Student>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            ValidationResult resukt = await this.validator.ValidateAsync(request);
            if(!resukt.IsValid)
            {
                ErrorResponse <Student>errorResponse = new ErrorResponse<Student>();
                foreach (var ex in resukt.Errors)
                    errorResponse.AddError(ex.PropertyName, ex.ErrorMessage);
                return errorResponse;

            }
            Student deletedStudent = await this.studentsRepository.SelectOneAsync(request.Id);
            if (deletedStudent == null) { throw new Exception("Student Not found"); }

            await this.studentsRepository.DeleteAsync(deletedStudent);
            SuccessResponse<Student> successResponse = new SuccessResponse<Student>();
            successResponse.Data = deletedStudent;
            return successResponse;
        }
    }
}
