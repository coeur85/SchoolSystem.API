namespace SchoolSystem.API.Domain.Communication.Reponse
{
    public class SchoolResponse<T>
    {
        public bool Success { get; init; }
        public T Data { get; set; }
        public Dictionary<string,string> Errors { get; set; }
    }
}
