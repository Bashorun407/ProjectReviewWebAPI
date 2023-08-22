using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectReview.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [Authorize(Roles ="Admin")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsers([FromQuery] UserRequestInputParameter parameter)
        {
            var result = await _userService.GetAllUsers(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result.Data.users);
        }


        [Authorize]
        [HttpGet("{id}/id")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var result = await _userService.GetById(id);
            return Ok(result);
        }

        // [Authorize]
        [HttpPost("{id}/image")]
        public IActionResult UploadProfilePic(string id, IFormFile file)
        {
            var result = _userService.UploadProfileImage(id, file);
            if (result.Result.Succeeded)
            {
                return Ok(new { ImageUrl = result.Result.Data.Item2 });
            }
            return NotFound();
        }

        // PUT api/<UserController>/5
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserRequestDto userRequestDto)
        {
            var result = await _userService.UpdateUser(id, userRequestDto);
            return Ok(result);
        }

        // DELETE api/<UserController>/5
        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUser(id);

            return Ok(result);
        }
    }
}
