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
        //[Authorize(Roles ="Admin")]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsers();
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data));
            return Ok(result);
        }


        //[Authorize]
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _userService.GetById(id);
            return Ok(result);
        }

        //[Authorize]
        [HttpGet("userId/{id}")]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var result = await _userService.GetByUserId(userId);
            return Ok(result);
        }

       //[Authorize]
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var result = await _userService.GetByEmail(email);
            return Ok(result);
        }

        //[Authorize]
        [HttpGet("phoneNumber/{phoneNumber}")]
        public async Task<IActionResult> GetUserByPhoneNumber(string phoneNumber)
        {
            var result = await _userService.GetByPhoneNumber(phoneNumber);
            return Ok(result);
        }

        // GET: api/<UserController>
        //[Authorize(Roles = "Admin")]
        [HttpGet("usersByRole")]
        public async Task<IActionResult> GetUsersByRole([FromQuery] UserRequestInputParameter parameter)
        {
            var result = await _userService.GetByRole(parameter);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }

        // GET: api/<UserController>
        //[Authorize(Roles = "Admin")]
        [HttpGet("getBySpecializatiion")]
        public async Task<IActionResult> GetUsersBySpecialization([FromQuery] UserRequestInputParameter parameter)
        {
            var result = await _userService.GetBySpecialization(parameter);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }

        // [Authorize]
        [HttpPost("image/{id}")]
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
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUser(id);

            return Ok(result);
        }
    }
}
