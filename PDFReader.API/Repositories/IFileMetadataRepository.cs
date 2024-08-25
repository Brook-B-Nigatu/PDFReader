using PDFReader.API.DBModels;

namespace PDFReader.API.Repositories
{
    public interface IFileMetadataRepository
    {
        Task<IEnumerable<FileMetadata>> GetAllFileMetadataAsync();
        Task AddFileMetadataAsync(FileMetadata data);

        Task DeleteFileMetadataAsync(int ID);
        Task GetFileMetadataAsync(int ID);

    }
}
