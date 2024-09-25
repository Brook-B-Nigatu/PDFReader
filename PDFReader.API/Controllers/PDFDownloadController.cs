using Microsoft.AspNetCore.Mvc;
using PDFReader.API.DBModels;
using PDFReader.API.FileManagement.Interface;
using PDFReader.API.Repositories.Interfaces;
using System.Runtime.CompilerServices;

namespace PDFReader.API.Controllers
{
    [Route("api/download")]
    [ApiController]
    public class PDFDownloadController : ControllerBase
    {
        private readonly IFileMetadataRepository _fileMetadataRepository;
        private readonly IFileManager _fileManager;
        private readonly ILogger<PDFDownloadController> _logger;
        public PDFDownloadController(IFileMetadataRepository fileMetadataRepository, 
                                    IFileManager fileManager,
                                    ILogger<PDFDownloadController> logger)
        {
            _fileMetadataRepository = fileMetadataRepository;
            _fileManager = fileManager;
            _logger = logger;
        }

        [HttpGet("")]
        public string[] GetList()
        {
            string username = "default";

            _logger.LogInformation($"fetching list of filenames available for user {username}...");

            string[] res = _fileMetadataRepository.GetFilesOfUser(username).Select(data => data.Name).ToArray();

            return res;
        }

        [HttpGet("{fileName}")]
        public IActionResult GetPDF(string filename)
        {
            string username = "default";

            _logger.LogInformation($"fetching file {filename} for user {username}");

            string path = _fileMetadataRepository.GetPath(filename, username);

            _logger.LogInformation($"file found at path {path}");
            
            return PhysicalFile(path, "application/pdf", filename);
        }

    }


}
