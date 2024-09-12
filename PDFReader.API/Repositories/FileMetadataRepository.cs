using PDFReader.API.DBModels;
using PDFReader.API.Repositories.Interfaces;

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

        public FileMetadata? GetFileMetadataByID(int id)
        {
            return _context.FileMetadata.Find(id);
        }

        public FileMetadata? GetFileMetadataByName(string name, string username)
        {
            return _context.FileMetadata.FirstOrDefault(data => (data.Name == name && data.Owner.UserName == username));
        }

        public string? GetPath(string name, string username)
        {
            return GetFileMetadataByName(name, username)?.Path;
        }

        public bool Exists(string filename, string username)
        {
            return _context.FileMetadata.Any(data => (data.Name == filename && data.Owner.UserName == username));
        }
    }
}
