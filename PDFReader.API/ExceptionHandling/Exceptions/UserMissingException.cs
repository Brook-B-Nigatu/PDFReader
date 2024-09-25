namespace PDFReader.API.ExceptionHandling.Exceptions
{
    public class UserMissingException : Exception
    {
        public UserMissingException() { }

        public UserMissingException(string message) : base(message) { }
    }
}
