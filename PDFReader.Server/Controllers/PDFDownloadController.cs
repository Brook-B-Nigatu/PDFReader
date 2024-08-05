using Microsoft.AspNetCore.Mvc;

namespace PDFReader.Server.Controllers
{
    [Route("api/download")]
    [ApiController]
    public class PDFDownloadController : ControllerBase
    {
        [HttpGet("")]
        public string[] GetList()
        {
            // Return an array of the available files
            string[] fileNames = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Files"));

            return fileNames.Select(s => Path.GetFileName(s)).ToArray();
        }

        [HttpGet("{fileName}")]
        public IActionResult GetPDF(string fileName)
        {
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "Files", fileName), "application/pdf", fileName);
        }

    }


}
