using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SchoolSystem.API.Domain.Communication.Response;
using SchoolSystem.API.Domain.Models.Students;
using SchoolSystem.API.Domain.Repositories;


namespace SchoolSystem.API.Domain.Commands.Students
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand,SchoolResponse>
    {
        private readonly IStudentsRepository studentsRepository;
        private readonly IValidator<DeleteStudentCommand> validator;

        public DeleteStudentCommandHandler(IStudentsRepository studentsRepository
            , IValidator<DeleteStudentCommand> validator)
        {
            this.studentsRepository = studentsRepository;
            this.validator = validator;
        }
        public async Task<SchoolResponse> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            ValidationResult resukt = await this.validator.ValidateAsync(request);
            if(!resukt.IsValid)
            {
                ErrorResponse errorResponse = new ErrorResponse(resukt.Errors);
                return errorResponse;

            }
            Student deletedStudent = await this.studentsRepository.SelectOneAsync(request.Id);
            await this.studentsRepository.DeleteAsync(deletedStudent);
            SchoolResponse successResponse = new SuccessResponse();
            successResponse.Data = deletedStudent;
            return successResponse;
        }
    }
}
