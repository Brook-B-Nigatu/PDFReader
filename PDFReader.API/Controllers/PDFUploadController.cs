using Microsoft.AspNetCore.Mvc;
using PDFReader.API.FileManagement.Interface;
using PDFReader.API.Repositories.Interfaces;
using PDFReader.API.DBModels;

namespace PDFReader.API.Controllers
{
    [ApiController]
    [Route("api/upload")]
    public class PDFUploadController : ControllerBase
    {
        private readonly IFileMetadataRepository _fileMetadataRepository;
        private readonly IUserRepository _userRepository;
        private readonly IFileManager _FileManager;
        private readonly ILogger<PDFUploadController> _logger;

        public PDFUploadController(IUserRepository userRepository, 
                                   IFileMetadataRepository fileMetadataRepository,
                                   IFileManager fileManager,
                                   ILogger<PDFUploadController> logger)
        {
            // inject services
            _userRepository = userRepository;
            _fileMetadataRepository = fileMetadataRepository;
            _FileManager = fileManager;
            _logger = logger;
        }

        [HttpPost("")]
        public IActionResult Upload(IFormFile file)
        {
            
            string username = "default";    // temporary until proper user-based system is implemented
            _logger.LogInformation($"creating file {file.FileName} for user {username}...");
            string path = _FileManager.StoreFile(file);
           
            {
                if (!_userRepository.Exists(username))
                {
                    _userRepository.AddUser(new User { UserName = username });
                }
            }

            User owner = _userRepository.GetUserByName(username);
            _fileMetadataRepository.AddFileMetadata(new FileMetadata { Name =file.FileName, Path = path, Owner = owner });

            _logger.LogInformation($"file created at {path}");
            return Ok();
        }
    }
}
