using Microsoft.AspNetCore.Mvc;

namespace PDFReader.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestPDFSendController : ControllerBase
    {
        [HttpGet("")]
        public ActionResult GetPDF()
        {

            return PhysicalFile(Path.GetFullPath("blank.pdf"), "application/pdf", "blank");
        }
    }
}
