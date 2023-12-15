using Microsoft.AspNetCore.Mvc;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Shared    .Dtos.RequestDtos;
using ProjectReviewWebAPI.Shared.Dtos.ResponseDto;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using Swashbuckle.AspNetCore.Annotations;
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

        /// <summary>
        /// This endpoint returns all Users
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>

        // GET: api/<UserController>
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<PagedList<UserResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        //[Authorize(Roles = "User")]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllUsers( [FromQuery] UserRequestInputParameter parameter)
        {
            var result = await _userService.GetAllUsers(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.MetaData));
            return StatusCode(result.StatusCode, result);
        }


        /// <summary>
        /// This endpoint returns a user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

        //[Authorize]
        //[Authorize(Roles = "User")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<UserResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        [HttpGet("userId/{userId}")]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var result = await _userService.GetByUserId(userId);
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
                }
        */

        /// <summary>
        /// This endpoint returns users by specified type which can be CLIENT or SERVICE_PROVIDER
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<PagedList<UserResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        //[Authorize(Roles = "Admin")]
        [HttpGet("usersByType/{type}")]
        public async Task<IActionResult> GetUsersByUserType([FromQuery] UserRequestInputParameter parameter) 
        {
            var result = await _userService.GetByUserType(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.MetaData));
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// This endpoint returns users by specialization given which can be EDITOR, REVIEWER, RESEARCHER, PROOF_READER
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="specialization"></param>
        /// <returns></returns>

        // GET: api/<UserController>
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<PagedList<UserResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        //[Authorize(Roles = "User")]
        [HttpGet("specializatiion/{specialization}")]
        public async Task<IActionResult> GetUsersBySpecialization([FromQuery] UserRequestInputParameter parameter)
        {
            var result = await _userService.GetBySpecialization(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.MetaData));
            return StatusCode(result.StatusCode, result);
        }

        //[Authorize(Roles = "User")]
        /* [HttpGet("allProjectsByUser/{userId}")]
        public async Task<IActionResult> GetAllProjectsByUserId([FromQuery]int pageNumber, string userId)
        {
            var result = await _userService.GetAllProjectsByUserId(pageNumber, userId);

            return Ok(result);
        }*/

        /// <summary>
        /// Returns all Service providers
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>

        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<PagedList<UserResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        [HttpGet("allServiceProviders")]
        public async Task<IActionResult> GetAllServiceProviders([FromQuery] UserRequestInputParameter parameter)
        {
            var result = await _userService.GetAllServiceProviders(parameter);

            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Returns a user by username. username is passed as a method parameter
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>

        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<UserResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        //[Authorize(Roles = "User")]
        [HttpGet("userByUsername/{username}")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var result = await _userService.GetByUsername(username);

            return Ok(result);
        }

        /// <summary>
        /// Displays user rating for a user by passing user-id of the user in the method parameter
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<UserResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        //[Authorize(Roles = "User")]
        [HttpGet("ratingsByUserId/{userId}")]
        public async Task<IActionResult> GetRatingByUserId(string userId)
        {
            var result = await _userService.GetRatingByUserId(userId);

            return Ok(result);
        }

        /// <summary>
        /// Enables users to upload profile picture from a folder on their device
        /// </summary>
        /// <param name="id"></param>
        /// <param name="file"></param>
        /// <returns></returns>

        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<UserResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        // [Authorize]
        //[Authorize(Roles = "User")]
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

        /// <summary>
        /// User can update user details via this endpoint
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userUpdateDto"></param>
        /// <returns></returns>

        // PUT api/<UserController>/5
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<UserUpdateResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        //[Authorize]
        //[Authorize(Roles = "User")]
        [HttpPut("userUpdate/{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserUpdateRequestDto userUpdateDto)
        {
            var result = await _userService.UpdateUser(id, userUpdateDto);
            return Ok(result);
        }

        /// <summary>
        /// Users that may want to update to Service provider will use this endpoint 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userUpdateDto"></param>
        /// <returns></returns>

        // PUT api/<UserController>/5
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<UserUpdateResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        //[Authorize]
        //[Authorize(Roles = "User")]
        [HttpPut("serviceProviderUpdate/{id}")]
        public async Task<IActionResult> ServiceProviderUpdate(string id, [FromBody] UserServiceProviderUpdateDto userUpdateDto)
        {
            var result = await _userService.ServiceProviderUpdate(id, userUpdateDto);
            return Ok(result);
        }

        /// <summary>
        /// Service provider updates details of job assigned via this endpoint
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userUpdateDto"></param>
        /// <returns></returns>

        // PUT api/<UserController>/5
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<UserUpdateResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        //[Authorize]
        //[Authorize(Roles = "User")]
        [HttpPut("jobRoleUpdate/{id}")]
        public async Task<IActionResult> JobRoleUpdate(string id, [FromBody] UserAdminUpdateDto userUpdateDto)
        {
            var result = await _userService.JobRoleUpdate(id, userUpdateDto);
            return Ok(result);
        }

        /// <summary>
        /// User can delete details via this endpoint by passing username as parameter type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // DELETE api/<UserController>/5
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<UserResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        //[Authorize(Roles = "User")]
        [HttpDelete("deleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUser(id);

            return Ok(result);
        }
    }
}
