namespace SchoolSystem.API.Domain.Communication.Reponse
{
    public class ErrorResponse<T>: SchoolResponse<T> where T : class
    {
        public ErrorResponse()
        {
            base.Success = false;
        }

        public void AddError(string propertyName,string message)
            =>  base.Errors.Add(propertyName, message);
        
    }
}
