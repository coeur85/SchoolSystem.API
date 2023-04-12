namespace SchoolSystem.API.Domain.Communication.Response
{
    public class SuccessResponse : SchoolResponse
    {
        public SuccessResponse()
        {
            base.Errors = null;
            base.Success = true;
        }

        public SuccessResponse(object data)
            : this()
            => base.Data = data;

    }
}
