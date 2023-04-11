namespace SchoolSystem.API.Domain.Communication.Reponse
{
    public class AppResponse<T>
    {
        public bool Success { get; init; }
        public T Data { get; set; }
        public Dictionary<string,string> Errors { get; set; }
    }
}
