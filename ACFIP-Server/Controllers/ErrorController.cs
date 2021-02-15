using Microsoft.AspNetCore.Mvc;

namespace ACFIP_Server.Controllers
{
    [ApiController]
    public class ErrorController : Controller
    {
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error() => Problem();
    }
}
