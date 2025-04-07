using DataAccessLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddController : Controller
    {
        private readonly AdService _adService;

        public AddController(AdService adService)
        {
            _adService = adService;
        }


        [HttpGet] //GetAll
        public async Task<ActionResult<List<AdDto>>> GetAll()
        {
            return Ok(await _dbContext.SuperHeroes.ToListAsync());
        }
    }
}
