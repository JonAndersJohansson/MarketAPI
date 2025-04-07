using DataAccessLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

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
        public async Task<ActionResult<List<AdDto>>> GetAllAsync()
        {
            try
            {
                var adsDto = await _adService.GetAllAsync();
                return Ok(adsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ett internt fel uppstod: {ex.Message}");
            }
        }

        //[HttpGet("{id}")] //GetById
        //public async Task<ActionResult<AdDto>> GetOneAsync(int id)
        //{

        //    var adDto = await _adService.GetByIdAsync(id);

        //    //var hero = _dbContext.SuperHeroes.Find(id);

        //    if (adDto == null)
        //    {
        //        return BadRequest("Ad not found");
        //    }
        //    return Ok(adDto);
        //}

        //[HttpPost] //Create
        //public async Task<ActionResult<AdCreateDto>> PostAsync(AdCreateDto adDto)
        //{

        //    _adService.CreateAsync(adDto);
        //    //await _dbContext.SaveChangesAsync();
        //    return Ok(await _dbContext.SuperHeroes.ToListAsync());
        //}
        //[HttpPut("{id}")] //Update
        //public async Task<ActionResult<AdUpdateDto>> UpdateAsync(AdUpdateDto adDto)
        //{
        //    // OBS: PUT Uppdaterar HELA SuperHero (ALLA properties)
        //    var adToUpdate = await _dbContext.SuperHeroes.FindAsync(hero.Id);

        //    if (heroToUpdate == null)
        //    {
        //        return BadRequest("Superhero not found");
        //    }
        //    heroToUpdate.Name = hero.Name;
        //    heroToUpdate.FirstName = hero.FirstName;
        //    heroToUpdate.SurName = hero.SurName;
        //    heroToUpdate.City = hero.City;

        //    await _dbContext.SaveChangesAsync();

        //    return Ok(await _dbContext.SuperHeroes.ToListAsync());

        //    return Ok(heroes);
        //}
    }
}
