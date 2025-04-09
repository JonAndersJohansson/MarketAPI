using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services;

namespace MarketAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet] //GetAll
        public async Task<ActionResult<List<UserDto>>> GetAllAsync()
        {
            var usersDto = await _userService.GetAllAsync();

            if (usersDto == null || usersDto.Count == 0)
            {
                return NotFound("No users found.");
            }

            return Ok(usersDto);
        }

        [HttpGet("{id}", Name = "GetUserById")] //GetOne
        public async Task<ActionResult<UserDto>> GetOneAsync(int id)
        {
            var userDto = await _userService.GetByIdAsync(id);

            if (userDto == null)
            {
                return NotFound("User not found.");
            }

            return Ok(userDto);
        }

        [HttpPost] //Create
        public async Task<ActionResult<UserDto>> PostAsync(UserCreateDto newUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdUser = await _userService.CreateAsync(newUserDto);

            if (createdUser == null)
            {
                return BadRequest("Could not create user.");
            }

            return CreatedAtRoute("GetUserById", new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")] //Put
        public async Task<ActionResult<UserUpdateDto>> PutAsync(int id, UserUpdateDto updatedUserDto)
        {
            if (id != updatedUserDto.Id)
                return BadRequest("Id mismatch.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userDto = await _userService.UpdateAsync(updatedUserDto);

            if (userDto == null)
                return NotFound("User not found.");

            return Ok(userDto);
        }

        [HttpDelete]
        [Route("{id}")] //Delete
        public async Task<ActionResult<UserDto>> Delete(int id)
        {
            var success = await _userService.DeleteAsync(id);
            if (!success)
            {
                return NotFound("User not found.");
            }

            return Ok("User deleted successfully.");
        }
    }
}
