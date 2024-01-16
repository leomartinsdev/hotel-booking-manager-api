using Microsoft.AspNetCore.Mvc;


namespace HotelManagerAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class StatusController : Controller
    {
        /// <summary>Identifica se a API está online. </summary>
        [HttpGet]
        public IActionResult GetMessage()
        {
            return Ok(new { message = "online" });
        }
    }
}
