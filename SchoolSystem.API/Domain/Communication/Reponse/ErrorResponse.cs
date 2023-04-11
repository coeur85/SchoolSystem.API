namespace SchoolSystem.API.Domain.Communication.Reponse
{
    public class ErrorResponse<T>: AppResponse<T> where T : class
    {
        public ErrorResponse()
        {
            base.Success = false;
        }

        public void AddError(string propertyName,string message)
            =>  base.Errors.Add(propertyName, message);
        
    }
}
