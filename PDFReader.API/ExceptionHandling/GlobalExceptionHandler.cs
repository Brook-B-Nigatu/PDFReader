using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PDFReader.API.ExceptionHandling.Exceptions;


namespace PDFReader.API.ExceptionHandling
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception ex, CancellationToken tok)
        {

            _logger.LogError(ex.Message);
            ProblemDetails problemDetails = new ProblemDetails
            {
                Detail = ex.Message,
                Instance = httpContext.Request.Path
            };

            switch (ex)
            {
                case FileMissingException:
                    problemDetails.Status = 404;
                    problemDetails.Title = "File Not Found";
                    break;

                case UserMissingException:
                    problemDetails.Status = 404;
                    problemDetails.Title = "User Not Found";
                    break;

                default:
                    problemDetails.Status = 500;
                    problemDetails.Title = "Internal Error";
                    problemDetails.Detail = "";     // Avoid revealing possibly sensitive info from the unknown exception
                    break;
            }

            httpContext.Response.StatusCode = problemDetails.Status.Value;
            await httpContext.Response.WriteAsJsonAsync(problemDetails);
            return true;
        }
    }
}


