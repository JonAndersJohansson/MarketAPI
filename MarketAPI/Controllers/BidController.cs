using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;

namespace MarketAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }


        [HttpGet] //GetAll
        public async Task<ActionResult<List<BidDto>>> GetAllAsync()
        {
            var bidsDto = await _bidService.GetAllAsync();

            if (bidsDto == null || bidsDto.Count == 0)
            {
                return NotFound("No bids found.");
            }

            return Ok(bidsDto);
        }

        [HttpGet("{id}", Name = "GetBidById")] //GetOne
        public async Task<ActionResult<BidDto>> GetOneAsync(int id)
        {
            var bidDto = await _bidService.GetByIdAsync(id);

            if (bidDto == null)
            {
                return NotFound("Bid not found.");
            }

            return Ok(bidDto);
        }

        [HttpPost] //Create
        public async Task<ActionResult<BidDto>> PostAsync(BidCreateDto newBidDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdBid = await _bidService.CreateAsync(newBidDto);

            if (createdBid == null)
            {
                return BadRequest("Could not create bid.");
            }

            return CreatedAtRoute("GetBidById", new { id = createdBid.Id }, createdBid);
        }

        [HttpPut("{id}")] //Put/UpdateAll
        public async Task<ActionResult<BidUpdateDto>> PutAsync(int id, BidUpdateDto updatedBidDto)
        {
            if (id != updatedBidDto.Id)
                return BadRequest("Id mismatch.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bidDto = await _bidService.UpdateAsync(updatedBidDto);

            if (bidDto == null)
                return NotFound("Bid not found.");

            return Ok(bidDto);
        }

        [HttpPatch("{id}")] //Patch/UpdatePart
        public async Task<IActionResult> PatchBid(int id, JsonPatchDocument<BidUpdateDto> patchDoc)
        {
            var bidDto = await _bidService.PatchAsync(id, patchDoc);

            if (bidDto == null)
                return NotFound();

            return Ok(bidDto);
        }

        [HttpDelete] //Delete (Soft)
        [Route("{id}")]
        public async Task<ActionResult<BidDto>> Delete(int id)
        {
            var success = await _bidService.DeleteAsync(id);
            if (!success)
            {
                return NotFound("Bid not found.");
            }

            return Ok("Bid deleted successfully.");
        }
    }
}
