namespace PDFReader.API.FileManagement.Interface
{
    public interface IFileManager
    {
        string DeterminePath(string filename, string username = "default");
        string StoreFile(IFormFile file, string userName = "default");   // store file and return path
        string[] GetFileNames(string userName = "default");
    }
}
