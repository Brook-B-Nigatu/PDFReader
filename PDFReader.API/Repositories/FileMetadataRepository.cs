using PDFReader.API.DBModels;
using PDFReader.API.Repositories.Interfaces;
using PDFReader.API.ExceptionHandling.Exceptions;

namespace PDFReader.API.Repositories
{
    public class FileMetadataRepository : IFileMetadataRepository
    {
        private readonly PDFReaderDBContext _context;
        public FileMetadataRepository(PDFReaderDBContext context)
        {
            _context = context;
        }

        public void AddFileMetadata(FileMetadata data)
        {
            _context.FileMetadata.Add(data);
            _context.SaveChanges();
        }

        public FileMetadata GetFileMetadataByID(int id)
        {
            return _context.FileMetadata.Find(id)?? throw new FileMissingException($"No file metadata with id {id}");
        }

        public FileMetadata GetFileMetadataByName(string filename, string username)
        {
            return _context.FileMetadata.FirstOrDefault(data => (data.Name == filename && data.Owner.UserName == username))
                ?? throw new FileMissingException($"User {username} owns no file with name {filename}");
        }

        public IEnumerable<FileMetadata> GetFilesOfUser(string username)
        {
            return _context.FileMetadata.Where(data => data.Owner.UserName == username);
        }

        public string GetPath(string filename, string username)
        {
            return GetFileMetadataByName(filename, username).Path;
        }

        public bool Exists(string filename, string username)
        {
            return _context.FileMetadata.Any(data => (data.Name == filename && data.Owner.UserName == username));
        }
    }
}
