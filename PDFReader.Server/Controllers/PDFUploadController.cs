using Microsoft.AspNetCore.Mvc;

namespace PDFReader.Server.Controllers
{
    [ApiController]
    [Route("api/upload")]
    public class PDFUploadController : ControllerBase
    {
        [HttpPost("")]
        public IActionResult Upload(IFormFile file)
        {
            // Handles files submitted via the upload form. Saves file to Files/ or does nothing
            // if it already exists. 

            
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Files", file.FileName);

            if (System.IO.File.Exists(path))
            {
                return Ok();
            }
            
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return Ok();
        }
    }
}
