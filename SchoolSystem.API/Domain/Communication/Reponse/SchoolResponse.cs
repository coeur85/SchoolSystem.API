namespace SchoolSystem.API.Domain.Communication.Response
{
    public class SchoolResponse
    {
        public bool Success { get; init; }
        public object Data { get; set; }
        public Dictionary<string,string> Errors { get; set; }
    }
}
