using Microsoft.EntityFrameworkCore;

namespace PDFReader.API.DBModels
{
    public class PDFReaderDB : DbContext
    {
        public virtual DbSet<FileMetaData> FileMetaData { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public PDFReaderDB(DbContextOptions<PDFReaderDB> options) : base(options) { }
    }
}
