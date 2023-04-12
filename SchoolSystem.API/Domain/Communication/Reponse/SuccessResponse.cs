namespace SchoolSystem.API.Domain.Communication.Response
{
    public class SuccessResponse<T> : SchoolResponse<T> where T : class
    {
        public SuccessResponse()
        {
            base.Success = true;
        }
    }
}
