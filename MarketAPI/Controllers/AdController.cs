using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;

namespace MarketAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdController : ControllerBase
    {
        private readonly IAdService _adService;

        public AdController(IAdService adService)
        {
            _adService = adService;
        }


        [HttpGet] //GetAll
        public async Task<ActionResult<List<AdDto>>> GetAllAsync()
        {
            var adsDto = await _adService.GetAllAsync();

            if (adsDto == null || adsDto.Count == 0)
            {
                return NotFound("No ads found.");
            }

            return Ok(adsDto);
        }

        [HttpGet("{id}", Name = "GetAdById")] //GetOne
        public async Task<ActionResult<AdDto>> GetOneAsync(int id)
        {
            var adDto = await _adService.GetByIdAsync(id);

            if (adDto == null)
            {
                return NotFound("Ad not found.");
            }

            return Ok(adDto);
        }

        [HttpPost] //Create
        public async Task<ActionResult<AdDto>> PostAsync(AdCreateDto newAdDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdAd = await _adService.CreateAsync(newAdDto);

            if (createdAd == null)
            {
                return BadRequest("Could not create ad.");
            }

            return CreatedAtRoute("GetAdById", new { id = createdAd.Id }, createdAd);


            //return Ok(createdAd); // bara för test

            //Console.WriteLine($"CREATED ID: {createdAd.Id}");
            //return CreatedAtAction(nameof(GetOneAsync), new { id = createdAd.Id }, createdAd);

        }

        //[HttpPut("{id}")] //Update
        //public async Task<ActionResult<AdUpdateDto>> UpdateAsync(AdUpdateDto newAdDto)
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
