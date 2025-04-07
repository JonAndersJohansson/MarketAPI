using Microsoft.AspNetCore.Mvc;

namespace MarketAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
