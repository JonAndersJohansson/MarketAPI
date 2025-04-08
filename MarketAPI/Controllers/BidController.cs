using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services;

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
                return NotFound("No users found.");
            }

            return Ok(bidsDto);
        }

        //[HttpGet("{id}", Name = "GetUserById")] //GetOne
        //public async Task<ActionResult<UserDto>> GetOneAsync(int id)
        //{
        //    var userDto = await _userService.GetByIdAsync(id);

        //    if (userDto == null)
        //    {
        //        return NotFound("User not found.");
        //    }

        //    return Ok(userDto);
        //}

        //[HttpPost] //Create
        //public async Task<ActionResult<UserDto>> PostAsync(UserCreateDto newUserDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var createdUser = await _userService.CreateAsync(newUserDto);

        //    if (createdUser == null)
        //    {
        //        return BadRequest("Could not create user.");
        //    }

        //    return CreatedAtRoute("GetUserById", new { id = createdUser.Id }, createdUser);
        //}

        //[HttpPut("{id}")] //Put
        //public async Task<ActionResult<UserUpdateDto>> PutAsync(int id, UserUpdateDto updatedUserDto)
        //{
        //    if (id != updatedUserDto.Id)
        //        return BadRequest("Id mismatch.");

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var userDto = await _userService.UpdateAsync(updatedUserDto);

        //    if (userDto == null)
        //        return NotFound("User not found.");

        //    return Ok(userDto);
        //}

        //[HttpDelete]
        //[Route("{id}")]
        //public async Task<ActionResult<UserDto>> Delete(int id)
        //{
        //    var success = await _userService.DeleteAsync(id);
        //    if (!success)
        //    {
        //        return NotFound("User not found.");
        //    }

        //    return Ok("User deleted successfully.");
        //}
    }
}
