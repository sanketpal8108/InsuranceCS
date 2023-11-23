using System.Net;

namespace InsuranceProject.Exceptions
{
    public class EntityNotFoundError:Exception
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public EntityNotFoundError(string message) : base(message)
        {
            StatusCode = (int)HttpStatusCode.NotFound;
            Message = message;
        }
    }
}
