﻿using Microsoft.AspNetCore.Mvc;
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

        //[HttpGet("{id}", Name = "GetAdById")] //GetOne
        //public async Task<ActionResult<AdDto>> GetOneAsync(int id)
        //{
        //    var adDto = await _userService.GetByIdAsync(id);

        //    if (adDto == null)
        //    {
        //        return NotFound("Ad not found.");
        //    }

        //    return Ok(adDto);
        //}

        //[HttpPost] //Create
        //public async Task<ActionResult<AdDto>> PostAsync(AdCreateDto newAdDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var createdAd = await _userService.CreateAsync(newAdDto);

        //    if (createdAd == null)
        //    {
        //        return BadRequest("Could not create ad.");
        //    }

        //    return CreatedAtRoute("GetAdById", new { id = createdAd.Id }, createdAd);
        //}

        //[HttpPut("{id}")] //Put
        //public async Task<ActionResult<AdUpdateDto>> PutAsync(int id, AdUpdateDto updatedAdDto)
        //{
        //    if (id != updatedAdDto.Id)
        //        return BadRequest("Id mismatch.");

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var adDto = await _userService.UpdateAsync(updatedAdDto);

        //    if (adDto == null)
        //        return NotFound("Ad not found.");

        //    return Ok(adDto);
        //}

        //[HttpDelete]
        //[Route("{id}")]
        //public async Task<ActionResult<AdDto>> Delete(int id)
        //{
        //    var success = await _userService.DeleteAsync(id);
        //    if (!success)
        //    {
        //        return NotFound("Ad not found.");
        //    }

        //    return Ok("Ad deleted successfully.");
        //}
    }
}
