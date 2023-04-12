using SchoolSystem.API.Domain.Models.Exceptions;

namespace SchoolSystem.API.Domain.Communication.Response
{
    public class ErrorResponse<T>: SchoolResponse<T>
    {
        public ErrorResponse()

        {
            base.Success = false;
            base.Errors = new Dictionary<string, string>();

        }

        public void AddError(string propertyName,string message)
            =>  base.Errors.Add(propertyName, message);
        public void AddError(SchoolExceptions exceptions)
            => base.Errors.Add(exceptions.PropertyName, exceptions.ErrorMessage);
        
    }
}
