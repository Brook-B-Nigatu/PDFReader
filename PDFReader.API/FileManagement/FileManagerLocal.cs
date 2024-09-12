using Microsoft.Extensions.Configuration.UserSecrets;
using PDFReader.API.FileManagement.Interface;
using System.Runtime.CompilerServices;

namespace PDFReader.API.FileManagement
{
    public class FileManagerLocal : IFileManager
    {
        public string DeterminePath(string filename, string username = "default")
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "Files", username, filename);
        }
        public string StoreFile(IFormFile file, string userName = "default")
        {

            string path = DeterminePath(file.FileName, userName);

            if (System.IO.File.Exists(path))
            {
                return path;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(path));

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }


            return path;
        }

        public string[] GetFileNames(string userName = "default")
        {
            string[] paths = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Files", "default"));
            
            return paths.Select(path => Path.GetFileName(path)).ToArray();
        }
    }
}
