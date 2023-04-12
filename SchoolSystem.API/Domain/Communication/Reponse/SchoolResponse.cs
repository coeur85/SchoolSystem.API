namespace SchoolSystem.API.Domain.Communication.Response
{
    public class SchoolResponse<T>
    {
        public bool Success { get; init; }
        public T Data { get; set; }
        public Dictionary<string,string> Errors { get; set; }
    }
}
