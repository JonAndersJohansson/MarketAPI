using Microsoft.AspNetCore.JsonPatch;
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
            var createdAd = await _adService.CreateAsync(newAdDto);

            if (createdAd == null)
            {
                return BadRequest("Could not create ad.");
            }

            return CreatedAtRoute("GetAdById", new { id = createdAd.Id }, createdAd);
        }

        [HttpPut("{id}")] //Put/UpdateAll
        public async Task<ActionResult<AdUpdateDto>> PutAsync(int id, AdUpdateDto updatedAdDto)
        {
            if (id != updatedAdDto.Id)
                return BadRequest("Id mismatch.");

            var adDto = await _adService.UpdateAsync(updatedAdDto);

            if (adDto == null)
                return NotFound("Ad not found.");

            return Ok(adDto);
        }

        [HttpPatch("{id}")] //Patch/UpdatePart
        public async Task<IActionResult> PatchAd(int id, JsonPatchDocument<AdUpdateDto> patchDoc)
        {
            var adDto = await _adService.PatchAsync(id, patchDoc);

            if (adDto == null)
                return NotFound();

            return Ok(adDto);
        }


        [HttpDelete] //Delete (Soft)
        [Route("{id}")]
        public async Task<ActionResult<AdDto>> Delete(int id)
        {
            var success = await _adService.DeleteAsync(id);
            if (!success)
            {
                return NotFound("Ad not found.");
            }

            return Ok("Ad deleted successfully.");
        }
    }
}
