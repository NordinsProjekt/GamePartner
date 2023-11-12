using Microsoft.AspNetCore.Mvc;
using MtGDomain.DTO;

namespace Portal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MagicSetController : Controller
    {
        [HttpGet("GetByCode")]
        public IActionResult Get()
        {
            return View();
        }

        [HttpGet("GetCardsWithFilter")]
        public IActionResult Get(MtGSearchFilterRecord filter)
        {
            return View();
        }
    }
}
