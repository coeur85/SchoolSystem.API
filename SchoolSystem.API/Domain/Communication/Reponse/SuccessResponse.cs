namespace SchoolSystem.API.Domain.Communication.Reponse
{
    public class SuccessResponse<T> : AppResponse<T> where T : class
    {
        public SuccessResponse()
        {
            base.Success = true;
        }
    }
}
