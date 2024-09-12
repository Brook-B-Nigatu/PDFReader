using PDFReader.API.DBModels;

namespace PDFReader.API.Repositories.Interfaces
{
    public interface IFileMetadataRepository
    {
        //TODO : 
        //     Implement other methods
        //     Make Asynchronous

        // Task<IEnumerable<FileMetadata>> GetAllFileMetadataAsync();
        void AddFileMetadata(FileMetadata data);

        // Task DeleteFileMetadataAsync(int ID);
        FileMetadata? GetFileMetadataByID(int id);

        FileMetadata? GetFileMetadataByName(string name, string username);

        string? GetPath(string filename, string username);

        bool Exists(string filename, string username);

    }
}
