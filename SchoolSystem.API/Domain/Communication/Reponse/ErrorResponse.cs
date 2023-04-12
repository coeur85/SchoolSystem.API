using FluentValidation.Results;
using SchoolSystem.API.Domain.Models.Exceptions;

namespace SchoolSystem.API.Domain.Communication.Response
{
    public class ErrorResponse : SchoolResponse
    {
        public ErrorResponse()

        {
            base.Success = false;
            base.Errors = new();
            base.Data = null;

        }

        public ErrorResponse(List<ValidationFailure> errors)
            : this()
            => AddErrors(errors);


        public void AddError(string propertyName, string message)
        {
            if (base.Errors.ContainsKey(propertyName))
            {
                var errors = base.Errors[propertyName];
                errors.Add(message);
                base.Errors[propertyName] = errors;
            }
            else
            {
                base.Errors.Add(propertyName, new List<string> { message });
            }
        }
        public void AddError(SchoolExceptions exceptions)
            => AddError(exceptions.PropertyName, exceptions.ErrorMessage);
        public void AddErrors(List<ValidationFailure> errors)
        {
            foreach (var error in errors)
                AddError(error.PropertyName, error.ErrorMessage);
        }

    }
}
