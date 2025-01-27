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

        [HttpGet("files/{username}")]
        public dynamic[] GetList(string username)
        {

            _logger.LogInformation($"fetching list of files available for user {username}...");

            var res = _fileMetadataRepository.GetFilesOfUser(username).Select(data => { return new {name = data.Name, id = data.ID}; }).ToArray();

            return res;
        }

        [HttpGet("{fileName}")]
        public IActionResult GetPDF(int fileId)
        {

            string path = _fileMetadataRepository.GetFileMetadataByID(fileId).Path;

            _logger.LogInformation($"file found at path {path}");
            
            return PhysicalFile(path, "application/pdf");
        }

    }


}
