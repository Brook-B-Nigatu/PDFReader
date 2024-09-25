namespace PDFReader.API.ExceptionHandling.Exceptions
{
    public class FileMissingException : Exception
    {
        public FileMissingException() { }

        public FileMissingException(string message) : base(message) { }
    }
}
