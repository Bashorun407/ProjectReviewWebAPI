using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;

using ProjectReviewWebAPI.Domain.Enums;

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


/*        //[Authorize]
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _userService.GetById(id);
            return Ok(result);
        }*/

        //[Authorize]
        [HttpGet("userId/{id}")]
        public async Task<IActionResult> GetByUserId([FromQuery] string userId)
        {
            var result = await _userService.GetByUserId(userId);
            return Ok(result);
        }

       //[Authorize]
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail([FromQuery] string email)
        {
            var result = await _userService.GetByEmail(email);
            return Ok(result);
        }

        //[Authorize]
        [HttpGet("phoneNumber/{phoneNumber}")]
        public async Task<IActionResult> GetUserByPhoneNumber([FromQuery] string phoneNumber)
        {
            var result = await _userService.GetByPhoneNumber(phoneNumber);
            return Ok(result);
        }

/*        // GET: api/<UserController>
        //[Authorize(Roles = "Admin")]
        [HttpGet("usersByRole/{role}")]
        public async Task<IActionResult> GetUsersByRole(UserRole role)
        {
            var result = await _userService.GetByRole(role);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }*/

        //[Authorize(Roles = "Admin")]
        [HttpGet("usersByType/{type}")]
        public async Task<IActionResult> GetUsersByUserType(UserType type)
        {
            var result = await _userService.GetByUserType(type);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }

        // GET: api/<UserController>
        //[Authorize(Roles = "Admin")]
        [HttpGet("specializatiion/{specialization}")]
        public async Task<IActionResult> GetUsersBySpecialization(Specialization specialization)
        {
            var result = await _userService.GetBySpecialization(specialization);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }

        [HttpGet("allProjectsByUser/{userId}")]
        public async Task<IActionResult> GetAllProjectsByUserId(string userId)
        {
            var result = await _userService.GetAllProjectsByUserId(userId);

            return Ok(result);
        }

        [HttpGet("allServiceProviders")]
        public async Task<IActionResult> GetAllServiceProviders()
        {
            var result = await _userService.GetAllServiceProviders();

            return Ok(result);
        }


        [HttpGet("ratingsByUserl/{userId}")]
        public async Task<IActionResult> GetRatingByUserId(string userId)
        {
            var result = await _userService.GetRatingByUserId(userId);

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
        [HttpPut("userId/{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserUpdateRequestDto userUpdateDto)
        {
            var result = await _userService.UpdateUser(id, userUpdateDto);
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
