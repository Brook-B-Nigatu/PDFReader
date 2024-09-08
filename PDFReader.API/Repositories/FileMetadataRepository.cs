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

        public FileMetadata? GetFileMetadataByName(string name)
        {
            return _context.FileMetadata.FirstOrDefault(data => data.Name == name);
        }

        public string? GetPath(string name)
        {
            return GetFileMetadataByName(name)?.Path;
        }
    }
}
