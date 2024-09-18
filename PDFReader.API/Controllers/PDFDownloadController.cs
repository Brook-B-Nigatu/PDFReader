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
            // Return an array of the available files for the requesting user
            string username = "default";
            string[] res = _fileMetadataRepository.GetFilesOfUser(username).Select(data => data.Name).ToArray();
            return res;
        }

        [HttpGet("{fileName}")]
        public IActionResult GetPDF(string filename)
        {
            string username = "default";
            string path = _fileMetadataRepository.GetPath(filename, username);
            
            return PhysicalFile(path, "application/pdf", filename);
        }

    }


}
