using FluentResults;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorController : ControllerBase
    {
        [HttpPost("/error")]
        public IActionResult Error()
        {
            //Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            //var (statusCode, message) = exception switch
            //{
            //    IError error => ((int)error.StatusCode, error.ErrorMessage),
            //    _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured.")
            //};

            ////return Problem();
            //return Problem(statusCode: statusCode, title: message);

            return Problem();
        }
    }
}
