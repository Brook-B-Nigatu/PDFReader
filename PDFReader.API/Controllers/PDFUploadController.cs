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

        public PDFUploadController(IUserRepository userRepository, 
                                   IFileMetadataRepository fileMetadataRepository,
                                   IFileManager fileManager)
        {
            // inject services
            _userRepository = userRepository;
            _fileMetadataRepository = fileMetadataRepository;
            _FileManager = fileManager;
        }

        [HttpPost("")]
        public IActionResult Upload(IFormFile file)
        {
            string userName = "default";    // temporary until proper user-based system is implemented
            string path = _FileManager.StoreFile(file);

            {
                if (!_userRepository.Exists(userName))
                {
                    _userRepository.AddUser(new User { UserName = userName });
                }
            }

            User owner = _userRepository.GetUserByName(userName);
            _fileMetadataRepository.AddFileMetadata(new FileMetadata { Name =file.Name, Path = path, Owner = owner });

            return Ok();
        }
    }
}
