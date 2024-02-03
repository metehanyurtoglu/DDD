using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class DinnersController : BaseController
    {
        [HttpGet]
        public IActionResult List()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
