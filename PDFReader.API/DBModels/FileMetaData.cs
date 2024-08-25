using System.ComponentModel.DataAnnotations;

namespace PDFReader.API.DBModels
{
    public class FileMetadata 
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public User Owner { get; set; }     // Navigation property to Users table 
        [Required]
        public int ReadCount {  get; set; }
        [Required]
        public int DownloadCount { get; set; }
        [Required]
        public DateTime UploadDate { get; set; }
        [Required]
        public DateTime LastDownloadDate { get; set; }

    }
}
