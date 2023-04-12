namespace SchoolSystem.API.Domain.Communication.Response
{
    public class SuccessResponse : SchoolResponse
    {
        public SuccessResponse()
        {
            base.Success = true;
        }
    }
}
