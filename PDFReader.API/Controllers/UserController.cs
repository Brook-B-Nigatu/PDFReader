using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PDFReader.API.Repositories.Interfaces;
using PDFReader.API.ExceptionHandling.Exceptions;

namespace PDFReader.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            _userRepository = userRepository;   
            _logger = logger;
        }

        [HttpPost("[action]")]
        public IActionResult Signup ()
        {
            string name = Request.Form["name"].ToString();
            string password = Request.Form["password"].ToString();

            if (_userRepository.Exists (name) )
            {
                throw new UsernameTakenException($"username {name} has already been taken!");
            }

            _userRepository.AddUser(new DBModels.User { UserName = name, Password = password });
            _logger.LogInformation($"new user created. username : {name}");

            return Created();
        }
    }
}
