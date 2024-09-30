using Microsoft.Identity.Client;

namespace PDFReader.API.ExceptionHandling.Exceptions
{
    public class UsernameTakenException : Exception
    {
        public UsernameTakenException() { }

        public UsernameTakenException(string message) : base(message) { }
    }
}
