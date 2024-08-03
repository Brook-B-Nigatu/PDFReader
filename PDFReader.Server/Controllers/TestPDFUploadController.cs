using Microsoft.AspNetCore.Mvc;

namespace PDFReader.Server.Controllers
{
    [ApiController]
    [Route("upload")]
    public class TestPDFUploadController : Controller
    {
        [HttpPost("")]
        public IActionResult Upload(IFormFile file)
        {
            Console.WriteLine("file received");
            return Ok();
        }
    }
}
