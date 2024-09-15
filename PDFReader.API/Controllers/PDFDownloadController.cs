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
        public PDFDownloadController(IFileMetadataRepository fileMetadataRepository, IFileManager fileManager)
        {
            _fileMetadataRepository = fileMetadataRepository;
            _fileManager = fileManager;
        }

        [HttpGet("")]
        public string[] GetList()
        {
            string username = "default";
            // Return an array of the available files
            
            //throw new Exception("Test Exception");
            return _fileManager.GetFileNames(username);
        }

        [HttpGet("{fileName}")]
        public IActionResult GetPDF(string filename)
        {
            string username = "default";
            string path = _fileManager.DeterminePath(filename, username);
            
            return PhysicalFile(path, "application/pdf", filename);
        }

    }


}
