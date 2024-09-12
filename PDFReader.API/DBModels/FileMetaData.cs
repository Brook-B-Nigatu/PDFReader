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
        
        public int ReadCount {  get; set; }
        
        public int DownloadCount { get; set; }
        
        public DateTime UploadDate { get; set; }
        
        public DateTime LastDownloadDate { get; set; }

    }
}
