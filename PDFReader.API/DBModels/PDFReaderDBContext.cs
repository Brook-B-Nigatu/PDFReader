using Microsoft.EntityFrameworkCore;

namespace PDFReader.API.DBModels
{
    public class PDFReaderDBContext : DbContext
    {
        public virtual DbSet<FileMetadata> FileMetadata { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public PDFReaderDBContext(DbContextOptions<PDFReaderDBContext> options) : base(options) { }
    }
}
