namespace SchoolSystem.API.Domain.Models.Exceptions
{
    public class SchoolExceptions : Exception
    {
        public string PropertyName { get; init; }
        public string ErrorMessage { get; init; }


        public SchoolExceptions(string propertyName, string msg)
        {
            this.PropertyName = propertyName;this.ErrorMessage = msg;
        }
    }
}
