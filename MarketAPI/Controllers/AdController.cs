using Microsoft.AspNetCore.Http.HttpResults;
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
        }

        [HttpPut("{id}")] //Put
        public async Task<ActionResult<AdUpdateDto>> PutAsync(int id, AdUpdateDto updatedAdDto)
        {
            if (id != updatedAdDto.Id)
                return BadRequest("Id mismatch.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var adDto = await _adService.UpdateAsync(updatedAdDto);

            if (adDto == null)
                return NotFound("Ad not found.");

            return Ok(adDto);
        }

    }
}
