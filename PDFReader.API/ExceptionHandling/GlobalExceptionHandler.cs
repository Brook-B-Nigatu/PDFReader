using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace PDFReader.API.ExceptionHandling
{
    public class GlobalExceptionHandler : IExceptionHandler 
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception ex, CancellationToken tok)
        {
            ProblemDetails problemDetails = new ProblemDetails
            {
                Status = 500,
                Title = "Test",
                Detail = ex.Message
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;
            await httpContext.Response.WriteAsJsonAsync(problemDetails);
            return true;
        }
    }
}
